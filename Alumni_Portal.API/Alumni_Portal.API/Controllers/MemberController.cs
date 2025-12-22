using Alumni_Portal.Models.RequestModels;
using Alumni_Portal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alumni_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPost]
        public async Task<IActionResult> AddMember(AddMemberRequestModel addMemberRequestModel)
        {
            var response = await _memberService.AddMember(addMemberRequestModel);
            return Ok(response);
        }
    }
}
