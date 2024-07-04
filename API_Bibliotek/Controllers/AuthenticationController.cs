using API_Bibliotek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Bibliotek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
       private readonly IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login([FromBody] User userModel)
        {
            if (userModel.Name == "Admin" && userModel.Password == "Hapro")
            {
                var token = GenerateJwtToken();
                return Ok(new { token });
            }
            return Unauthorized();
        }


        private string GenerateJwtToken()
        {
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "test")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

