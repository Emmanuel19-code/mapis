using mapis.Domain;
using mapis.Services;
using Microsoft.AspNetCore.Mvc;

namespace mapis.Controllers
{
    [Route("/api/member/controller")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEvents _event;
        public EventController(IEvents events)
        {
            _event = events;
        }
        [HttpPost("addEvents")]
        public async Task<ActionResult> UploadEvent(UploadEvent request)
        {
            var response = await _event.AddEvent(request);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("allEvents")]
        public async Task<ActionResult<IEnumerable<AllEvents>>> GetAllEvents()
        {
            var response = await _event.GetEvents();
            return Ok(response);
        }

       [HttpPut("updateEvent/{eventId}")]
       public async Task<ActionResult> UpdateEvent(Guid eventId,[FromBody] UpdateEvent request)
        {
            var response = await _event.UpdateEvent(eventId,request);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("registerEvent/{eventId}")]
        public async Task<ActionResult> RegisterEvent(Guid eventId,[FromBody]RegisterEvent request)
        {
            var response = await _event.RegisterEvent(eventId,request);
            if(!response.Success)
            {
                return BadRequest(response);
            }
           return Ok(response);
        }
       
    }
}