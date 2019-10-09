using ConferenceSignalR.Akka.ActorModels.Models;

namespace ConferenceSignalR.Akka.ActorModels.Messages
{
    public class UserStatusMessage
    {
        public ConferenceUser User { get; private set; }
        public UserStatusMessage(ConferenceUser user)
        {
            User = user;
        }
    }
}
