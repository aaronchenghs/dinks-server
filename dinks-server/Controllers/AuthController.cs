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

            return Ok(new { Token = token, User = response });
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
