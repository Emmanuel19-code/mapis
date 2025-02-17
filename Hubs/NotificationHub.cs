using Microsoft.AspNetCore.SignalR;

namespace mapis.Hubs
{
    public class  NotificationHub: Hub
    {
        public async Task RegisterNotice(Guid applicationId)
        {
            await Clients.All.SendAsync("Registration",$"A new application Received with {applicationId}");
        }

        public async Task NewEventNotice()
        {
            await Clients.All.SendAsync("newEvent","")
        } 
    }
}