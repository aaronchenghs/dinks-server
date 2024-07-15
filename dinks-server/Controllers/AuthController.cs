using AutoMapper;
using dinks_server.DTOs;
using dinks_server.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace dinks_server.Controllers
{
    public class AuthValidators : AbstractValidator<SignupRequest>
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

    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IValidator<SignupRequest> _validator;

        public AuthController(ApplicationDbContext context, IMapper mapper, IValidator<SignupRequest> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupRequest request)
        {
            ValidationResult result = _validator.Validate(request);

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
                Username = request.Email.Split('@')[0],
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "User registered successfully" });
        }
    }
}
