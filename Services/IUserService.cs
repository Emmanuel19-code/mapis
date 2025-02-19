using mapis.Domain;

namespace mapis.Services
{
    public interface IUserService
    {
        Task Login(AccountLogin request);
        Task<UserDetails> GetUserDetails(GetUserDetailsInfo request);
        Task UpdatePassord();
        Task<List<AllEvents>> GetRegisteredEvents(UserEventsRegistered request);
        Task<CreatedResponse> MakeComplain(ComplainDto request);
    }
}