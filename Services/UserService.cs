using mapis.Domain;
using mapis.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace mapis.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CreatedResponse> CreateAccount(BeComeMember request)
        {
            if(request == null)
            {
                return null;
            }

            var existingUser = await _context.CiltUser.FirstOrDefaultAsync(u=>u.Email == request.Email);
            if(existingUser != null)
            {
                return new CreatedResponse{
                    Success = false,
                    StatusCode = 400,
                    Message = "Account Already available"
                };
            }

            return new CreatedResponse
            {
                
                Message = "Account created successfully.",
                Success = true
            };
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