using Alumni_Portal.Models.RequestModels;
using Alumni_Portal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alumni_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionController : ControllerBase
    {
        private readonly IInstitutionService _institutionService;

        public InstitutionController(IInstitutionService institutionService)
        {
            _institutionService = institutionService;
        }

        [HttpPost]
        [Route("save-institution")]
        public async Task<IActionResult> Post(InstitutionRequestModel institutionRequestModel)
        {
            var result = await _institutionService.SaveInstitution(institutionRequestModel);
            return Ok(result);
        }
    }
}
