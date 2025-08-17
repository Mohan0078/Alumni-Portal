using Alumni_Portal.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alumni_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
      [HttpPost]
      public async Task<IActionResult> AddMember(AddMemberRequestModel addMemberRequestModel)
      {
        return Ok();
      }
    }
}
