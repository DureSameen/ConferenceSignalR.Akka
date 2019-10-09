using ConferenceSignalR.Akka.ActorModels.Models;

namespace ConferenceSignalR.Akka.ActorModels.Messages
{
    public class JoinConferenceRequest
    {
        public ConferenceUser User  { get; private set; }

        public JoinConferenceRequest(string userName )
        {
            User = new ConferenceUser(  userName, UserStatus.Available);
            
        
        }
    }
}
