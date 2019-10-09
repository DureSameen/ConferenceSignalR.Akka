using Akka.Actor;

namespace ConferenceSignalR.Akka.Web.Models
{
    public class ActorReferences
    {
        public IActorRef ConferenceController
        {
            get; set;
        }
        public IActorRef SignalRBridge
        {
            get; set;
        }
    }
}
