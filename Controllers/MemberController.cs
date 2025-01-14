using mapis.Domain;
using mapis.Services;
using Microsoft.AspNetCore.Mvc;

namespace mapis.Controllers
{
    [Route("/api/member/controller")]
    [ApiController]
    public class MemberController : ControllerBase
    {
      private readonly IUserService _userService;
      public MemberController(IUserService userService)
      {
            _userService = userService;
      }

      [HttpGet]
      

      [HttpPost("register")]
      public async Task<ActionResult> RegisterUser(BeComeMember request)
      {
        var response = await _userService.CreateAccount(request);
        if(!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
      }
    }
}