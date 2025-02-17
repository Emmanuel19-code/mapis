using mapis.Domain;
using mapis.Hubs;
using mapis.Infrastructure;
using Microsoft.AspNetCore.SignalR;

namespace mapis.Services
{
    public class UserService : IUserService
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context,IHubContext<NotificationHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
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

        public async Task<CreatedResponse> MakeComplain(ComplainDto request)
        {
            if(request == null)
            {
                return new CreatedResponse
                {
                    Success=false,
                    StatusCode = 400,
                    Message = "Provide the missing fields"
                };
            }
            var complain = new Complains
            {
                Type = request.ComplainType,
                FullName = request.FullName,
                Email = request.Email,
                Issue = request.Issue
            };
            var notification = new Notifications
            {
                Title = "Registration Notice",
                Message = $"A new Complain received from  {complain.FullName} "
            };
            await _context.Complains.AddAsync(complain);
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("Issue","A new Issue Received");
            return new CreatedResponse
            {
                Success = true,
                StatusCode = 201,
                Message = "Issue Sent Will be attended to shortly"
            };
        }

        public Task UpdatePassord()
        {
            throw new NotImplementedException();
        }
    }
}