using Microsoft.AspNetCore.SignalR;

namespace mapis.Hubs
{
    public class  NotificationHub: Hub
    {
        public async Task RegisterNotice(Guid applicationId)
        {
            await Clients.All.SendAsync("Registration",$"A new application Received with {applicationId}");
        }
    }
}