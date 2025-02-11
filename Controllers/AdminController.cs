using mapis.Domain;
using mapis.Services;
using Microsoft.AspNetCore.Mvc;

namespace mapis.Controllers
{
    [Route("/api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpGet("all_applications")]
        public async Task<ActionResult> GetAllApplications()
        {
            var response = await _adminService.GetAllApplications();
            return Ok(response);
        }

        [HttpPut("approve_application/{applicationId}")]
        public async Task<ActionResult> ApproveApplicantApplication(Guid applicationId)
        {
            var response =await _adminService.ApproveApplication(applicationId);
            if(response.StatusCode != 200)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("admin_access")]
        public async Task<ActionResult> AdminAcess(AdminLoginRequest request)
        {
            return Ok();
        }

        [HttpGet("applicants_info/{applicationId}")]
        public async Task<ActionResult<ApplicantsResponseInfo<ApplicantsInfo>>> GetApplicantDetails(Guid applicationId)
        {
            var response = await _adminService.GetApplicantsInfo(applicationId);
            if(response.StatusCode != 200)
            {
                return response;
            }
            return response;
        }

    }
}