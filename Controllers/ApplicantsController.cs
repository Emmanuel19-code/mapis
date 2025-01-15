using mapis.Domain;
using mapis.Services;
using Microsoft.AspNetCore.Mvc;

namespace mapis.Controllers
{
    [Route("/api/applicants")]
    public class ApplicantController : ControllerBase
    {
      private readonly IApplicantsService _applicantsService;
      public ApplicantController(IApplicantsService applicantsService)
      {
        _applicantsService = applicantsService;
      }
     [HttpPost("apply")]
      public async Task<ActionResult<ApplyResponse>> MemberApplication(ApplyDetails request)
      {
        var response = await _applicantsService.ApplicantsApply(request);
        if(response.StatusCode != 200)
        {
            return new ApplyResponse
            {
                StatusCode = response.StatusCode,
                Message = response.Message
            };
        }
        return Ok(response); 
      }

      [HttpPost("check_status")]
      public async Task<ActionResult<ApplyResponse>> CheckStatus(CheckStatus request)
      {
        var response =await _applicantsService.CheckApplicationStatus(request);
        if(response.StatusCode!= 200)
        {
            return BadRequest(response);
        }
        return Ok(response);
      }
    }
}