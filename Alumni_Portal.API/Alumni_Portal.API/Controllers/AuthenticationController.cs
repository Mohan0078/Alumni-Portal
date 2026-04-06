using Alumni_Portal.Models.RequestModels;
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

        [HttpPost]
        public async Task<IActionResult> GetToken(LoginModel loginModel)
        {
            var token = await _authenticationService.GenerateToken(loginModel);
            return Ok(token);
        }
    }
}
