using mapis.Domain;

namespace mapis.Services
{
    public interface IEventService
    {
        Task<List<AllEvents>> GetEvents();
        Task<CreatedResponse> AddEvent(UploadEvent request);
        Task<CreatedResponse> UpdateEvent(Guid EventId, UpdateEvent request);
        Task<CreatedResponse> RegisterEvent(Guid eventId,RegisterEvent request);
    }
}