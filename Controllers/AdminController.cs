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

        [HttpPut("update_status")]
        public async Task<ActionResult> UpdateApplicantStatus(UpdateAplicantStatus request)
        {
            var response =await _adminService.ApproveApplication(request);
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

    }
}