using Alumni_Portal.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Alumni_Portal.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateToken(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
