using mapis.Domain;
using mapis.Hubs;
using mapis.Infrastructure;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace mapis.Services
{
    public class EventService : IEventService
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly ApplicationDbContext _context;
        public EventService(IHubContext<NotificationHub> hubContext, ApplicationDbContext context)
        {
            _hubContext = hubContext;
            _context = context;
        }
        public async Task<CreatedResponse> AddEvent(UploadEvent request)
        {
            if (request == null)
            {
                return new CreatedResponse
                {
                    Success = false,
                    StatusCode = 400,
                    Message = "Provide All Details"
                };
            }
            var eventAvailable = await _context.Events.FirstOrDefaultAsync(e => e.EventName == request.EventName);
            if (eventAvailable != null)
            {
                return new CreatedResponse
                {
                    Success = false,
                    StatusCode = 400,
                    Message = "Event Already Uploaded"
                };
            }
            var newEvent = new Events
            {
                EventName = request.EventName,
                EventType = request.EventType,
                Venue = request.Venue,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };
            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("eventNotice", "A new Event Has been Uploaded");
            return new CreatedResponse
            {
                Success = true,
                StatusCode = 200,
                Message = "Event Successful"
            };
        }

        public Task<List<AllEvents>> GetEvents()
        {
           var events = _context.Events.Select(e=>new AllEvents{
              EventId = e.EventId,
              EventName = e.EventName,
              EventType = e.EventType,
              Venue = e.Venue,
              StartDate = e.StartDate,
              EndDate = e.EndDate,
              StartTime = e.StartTime,
              EndTime = e.EndTime,
           }).ToListAsync();
           return events;
        }
 
        public async Task<CreatedResponse> RegisterEvent(Guid eventId, RegisterEvent request)
        {
            if( request == null)
            {
                return new CreatedResponse
                {
                    Success = false,
                    StatusCode = 400,
                    Message = "Could Not RegisterEvnet Provide Missing Information"
                };
            }
            var eventRegistration = new EventRegistration
            {
                EventId = eventId,
                CILTUserId = request.CILTUserId,
            };
            await _context.RegisterEvents.AddAsync(eventRegistration);
            await _context.SaveChangesAsync();
            return new CreatedResponse
            {
                Success = true,
                StatusCode = 200,
                Message = "Event Registered"
            };
        }

        public Task<CreatedResponse> UpdateEvent(Guid EventId, UpdateEvent request)
        {
            throw new NotImplementedException();
        }
    }
}