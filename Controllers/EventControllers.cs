using mapis.Domain;
using mapis.Services;
using Microsoft.AspNetCore.Mvc;

namespace mapis.Controllers
{
    [Route("/api/event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        
        [HttpPost("addEvents")]
        public async Task<ActionResult> UploadEvent(UploadEvent request)
        {
            return Ok();
        }
        [HttpGet("allEvents")]
        public async Task<ActionResult<IEnumerable<AllEvents>>> GetAllEvents()
        {
           return Ok();
        }

       [HttpPut("updateEvent/{eventId}")]
       public async Task<ActionResult> UpdateEvent(Guid eventId,[FromBody] UpdateEvent request)
        {
           return Ok();
        }

        [HttpPost("registerEvent/{eventId}")]
        public async Task<ActionResult> RegisterEvent(Guid eventId,[FromBody]RegisterEvent request)
        {
            return Ok();
        }
       
    }
}