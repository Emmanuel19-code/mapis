using mapis.Domain;

namespace mapis.Services
{
    public class EventService : IEventService
    {
        public Task<CreatedResponse> AddEvent(UploadEvent request)
        {
            throw new NotImplementedException();
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