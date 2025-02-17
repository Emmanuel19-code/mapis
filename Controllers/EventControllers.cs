using mapis.Domain;
using mapis.Services;
using Microsoft.AspNetCore.Mvc;

namespace mapis.Controllers
{
    [Route("/api/event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        
        [HttpPost("addEvents")]
        public async Task<CreatedResponse> UploadEvent(UploadEvent request)
        {
           var response = await _eventService.AddEvent(request);
           return response;
        }
        [HttpGet("allEvents")]
        public async Task<List<AllEvents>> GetAllEvents()
        {
           var events = await _eventService.GetEvents();
           return events;
        }

       [HttpPut("updateEvent/{eventId}")]
       public async Task<ActionResult> UpdateEvent(Guid eventId,[FromBody] UpdateEvent request)
        {
           return Ok();
        }

        [HttpPost("registerEvent/{eventId}")]
        public async Task<CreatedResponse> RegisterEvent(Guid eventId,[FromBody]RegisterEvent request)
        {
            var response = await _eventService.RegisterEvent(eventId,request);
            return response;
        }
       
    }
}