using AutoMapper;
using dinks_server.DTOs;
using dinks_server.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.Data;
using System.Security.Cryptography;

namespace dinks_server.Controllers
{
    public class AuthValidators : AbstractValidator<SignupRequestDTO>
    {
        public AuthValidators()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }

    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }

    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IValidator<SignupRequestDTO> _signupValidator;
        private readonly IValidator<LoginRequest> _loginValidator;
        private readonly IConfiguration _configuration;

        public AuthController(
           ApplicationDbContext context,
           IMapper mapper,
           IValidator<SignupRequestDTO> signupValidator,
           IValidator<LoginRequest> loginValidator,
           IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _signupValidator = signupValidator;
            _loginValidator = loginValidator;
            _configuration = configuration;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupRequestDTO request)
        {
            ValidationResult result = _signupValidator.Validate(request);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var userExists = _context.Users.Any(u => u.Email == request.Email);
            if (userExists)
            {
                return BadRequest("User already exists with this email.");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = request.Email.Split('@')[0],
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "User registered successfully" });
        }

        [HttpPost("signin")]
        public async Task<IActionResult> Signin([FromBody] LoginRequest request)
        {
            ValidationResult validationResult = _loginValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid email or password.");
            }

            var response = _mapper.Map<UserDTO>(user);
            var token = GenerateJwtToken(user);

            var refreshToken = GenerateRefreshToken();
            user.RefreshTokens.Add(refreshToken);
            await _context.SaveChangesAsync();

            SetTokenCookie(refreshToken.Token);

            return Ok(new { Token = token, User = response });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var user = await _context.Users.Include(u => u.RefreshTokens).SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));

            if (user == null)
            {
                return Unauthorized("Invalid refresh token.");
            }

            var token = user.RefreshTokens.Single(x => x.Token == refreshToken);

            if (!token.IsActive)
            {
                return Unauthorized("Invalid refresh token.");
            }

            var newRefreshToken = GenerateRefreshToken();
            token.Revoked = DateTime.UtcNow;
            user.RefreshTokens.Add(newRefreshToken);

            await _context.SaveChangesAsync();

            var jwtToken = GenerateJwtToken(user);

            SetTokenCookie(newRefreshToken.Token);

            return Ok(new { Token = jwtToken });
        }

        [HttpGet("validate-token")]
        public IActionResult ValidateToken()
        {
            try
            {
                var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Issuer"],
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                // Log the claims for debugging
                foreach (var claim in principal.Claims)
                {
                    Console.WriteLine($"{claim.Type}: {claim.Value}");
                }

                return Ok();
            }
            catch
            {
                return Unauthorized();
            }
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUser()
        {
            // Filter claims with the nameidentifier type and validate them as Guids
            var nameIdentifierClaims = User.Claims
                .Where(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                .ToList();

            Guid userId;
            var validGuidClaim = nameIdentifierClaims.FirstOrDefault(claim => Guid.TryParse(claim.Value, out userId));

            if (validGuidClaim == null)
            {
                return Unauthorized("No valid user ID claim found");
            }

            // Parse the valid user ID
            userId = Guid.Parse(validGuidClaim.Value);

            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = new UserDTO
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Dob = user.DateOfBirth,
                CreatedAt = user.CreatedAt,
                IsActive = user.IsActive,
                IconPath = user.IconPath
            };

            return Ok(userDto);
        }


        private RefreshToken GenerateRefreshToken()
        {
            return new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow
            };
        }

        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), 
        new Claim(ClaimTypes.Name, user.UserName) 
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddDays(14),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



    }
}