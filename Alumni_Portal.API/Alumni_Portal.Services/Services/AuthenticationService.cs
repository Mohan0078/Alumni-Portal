using Alumni_Portal.Services.Interfaces;
using EntityModels.Models;
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
        private readonly AlumniPortalContext _alumniPortalContext;

        public AuthenticationService(IConfiguration configuration, AlumniPortalContext alumniPortalContext)
        {
            _configuration = configuration;
            _alumniPortalContext = alumniPortalContext;
        }

        public async Task<string> GenerateToken(string email, string password)
        {
            try
            {
                var memberDBSet = _alumniPortalContext.Members;
                var contactDetailsDBSet = _alumniPortalContext.ContactDetails;

                var userName = (from member in memberDBSet
                                 join contactDetail in contactDetailsDBSet.Where(x => x.Email == email)
                                 on member.ContactDetailsId equals contactDetail.ContactDetailsId
                                 select member.FirstName).FirstOrDefault();

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
