using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Polotno.API.Models;
using Polotno.API.Repositories;
using Polotno.API.DTO;

namespace Polotno.API.Controllers
{
    [Route("fainoteam")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IConfiguration configuration;

        public AuthController(IUserRepository userRepository, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
        {
            // Validate user credentials (you can implement your own password checking logic)
            var user = await userRepository.FindByUsernameAsync(loginDto.Username);
            if (user == null || !VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            // Create claims for the token
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            // Retrieve the key from configuration
            var key = Encoding.ASCII.GetBytes(configuration["JwtSettings:Key"]!);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = configuration["JwtSettings:Issuer"],
                Audience = configuration["JwtSettings:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return Ok(new { token });
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AddRequestUserDto registerDto)
        {
            // Check if user already exists by email
            var existingUserByEmail = await userRepository.FindByEmailAsync(registerDto.Email);
            if (existingUserByEmail != null)
            {
                return Conflict(new { message = "User with this email already exists" });
            }

            // Check by username as well
            var existingUserByUsername = await userRepository.FindByUsernameAsync(registerDto.Username);
            if (existingUserByUsername != null)
            {
                return Conflict(new { message = "User with this username already exists" });
            }

            // Create a new user instance
            var newUser = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = HashPassword(registerDto.Password),
                CreatedAt = DateTime.UtcNow
            };

            await userRepository.AddAsync(newUser);

            // Optionally, return a JWT token right away (or simply a success message)
            return Ok(new { message = "Registration successful" });
        }
        

        // Replace the dummy methods with implementations using BCrypt
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
        }
    }
}
