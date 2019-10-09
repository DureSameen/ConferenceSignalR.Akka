using ConferenceSignalR.Akka.ActorModels.Models;

namespace ConferenceSignalR.Akka.ActorModels.Messages
{
    public class RefreshUserStatusMessage
    {
        public ConferenceUser User { get; set; }
        public RefreshUserStatusMessage(ConferenceUser user)
        {
            User = user;
        }
    }
}
