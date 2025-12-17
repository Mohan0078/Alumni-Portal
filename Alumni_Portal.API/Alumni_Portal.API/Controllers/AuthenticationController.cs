using Alumni_Portal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Alumni_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetToken(string email, string password)
        {
            var token = await _authenticationService.GenerateToken(email, password);
            return Ok(token);
        }
    }
}
