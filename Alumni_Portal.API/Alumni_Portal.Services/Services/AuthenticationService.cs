using Alumni_Portal.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Alumni_Portal.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateToken(string email, string password)
        {
            try
            {
                string userName = "Get this from DB";
                var jwtSettings = _configuration.GetSection("Jwt");
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));

                var claims = new[]
                {
                 new Claim(JwtRegisteredClaimNames.Sub, userName),
                 new Claim(JwtRegisteredClaimNames.Email, email),
                 new Claim(ClaimTypes.Role, "Test"),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken(
                            issuer: jwtSettings["Issuer"],
                            audience: jwtSettings["Audience"],
                            claims: claims,
                            expires: DateTime.UtcNow.AddMinutes(
                            Convert.ToDouble(jwtSettings["ExpireMinutes"])
                            ),
                            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                            );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
