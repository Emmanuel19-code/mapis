using mapis.Domain;

namespace mapis.Services
{
    public class UserService : IUserService
    {
        public Task<CreatedResponse> CreateAccount(BeComeMember request)
        {
            throw new NotImplementedException();
        }

        public Task<List<AllEvents>> GetRegisteredEvents(UserEventsRegistered request)
        {
            throw new NotImplementedException();
        }

        public Task<UserDetails> GetUserDetails(GetUserDetailsInfo request)
        {
            throw new NotImplementedException();
        }

        public Task Login(AccountLogin request)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePassord()
        {
            throw new NotImplementedException();
        }
    }
}