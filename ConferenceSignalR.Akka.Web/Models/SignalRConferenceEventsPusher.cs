using ConferenceSignalR.Akka.ActorModels.ExternalSystems;
using ConferenceSignalR.Akka.ActorModels.Models;
using ConferenceSignalR.Akka.Web.ConferenceHubs;
using Microsoft.AspNetCore.SignalR;

namespace ConferenceSignalR.Akka.Web.Models
{
    public class SignalRConferenceEventsPusher: IConferenceEventsPusher

    {
        public IHubContext<ConferenceHub> _hubContext;
       
        public SignalRConferenceEventsPusher(IHubContext<ConferenceHub> hubContext)
        {
            _hubContext = hubContext;
        }

        

        public void UserJoined(ConferenceUser user)
        {
            _hubContext.Clients.All.SendAsync("UserJoined", user);
        }

        public void UpdateUserStatus(ConferenceUser user)
        {
            _hubContext.Clients.All.SendAsync("UpdateUserStatus", user);
        }
    }
}
