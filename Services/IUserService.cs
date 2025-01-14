using mapis.Domain;

namespace mapis.Services
{
    public interface IUserService
    {
        Task<CreatedResponse> CreateAccount(BeComeMember request);
        Task Login(AccountLogin request);
        Task<UserDetails> GetUserDetails(GetUserDetailsInfo request);
        Task UpdatePassord(); 
    }
}