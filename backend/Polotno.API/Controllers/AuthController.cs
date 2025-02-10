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

        // Dummy password verification. Replace with your actual logic!
        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            // For demonstration, we assume storedHash is the plain password.
            // In a real-world scenario, compare hashes using an appropriate hashing algorithm.
            return enteredPassword == storedHash;
        }
    }
}
