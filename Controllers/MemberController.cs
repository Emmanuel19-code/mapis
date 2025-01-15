using mapis.Domain;
using mapis.Services;
using Microsoft.AspNetCore.Mvc;

namespace mapis.Controllers
{
  [Route("/api/member")]
  [ApiController]
  public class MemberController : ControllerBase
  {
    

    [HttpGet]


    [HttpPost("register")]
    public async Task<ActionResult> RegisterUser(BeComeMember request)
    {
      return Ok();
    }

    [HttpPost("myEvents")]
    public async Task<ActionResult> MyEvents(UserEventsRegistered request)
    {
       return Ok();
    }
  }
}