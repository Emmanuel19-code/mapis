using mapis.Domain;

namespace mapis.Services
{
    public class EventService : IEventService
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly ApplicationDbContext _context
        public EventService(IHubContext<NotificationHub> hubContext,ApplicationDbContext context)
        {
            _hubContext = hubContext;
            _context = context;
        }
        public async Task<CreatedResponse> AddEvent(UploadEvent request)
        {
             if(request == null)
             {
                return new CreatedResponse
                {
                    Success= false,
                    StatusCode =400,
                    Message = "Provide All Details"
                }
             }
             var eventAvailable = await _context.Events.FirstOrDefaultAsync(e=>);
            _hubContext.Clients.All.SendAsync("eventNotice","A new Event Has been Uploaded")
        }

        public Task<List<AllEvents>> GetEvents()
        {
            throw new NotImplementedException();
        }

        public Task<CreatedResponse> RegisterEvent(Guid eventId, RegisterEvent request)
        {
            throw new NotImplementedException();
        }

        public Task<CreatedResponse> UpdateEvent(Guid EventId, UpdateEvent request)
        {
            throw new NotImplementedException();
        }
    }
}