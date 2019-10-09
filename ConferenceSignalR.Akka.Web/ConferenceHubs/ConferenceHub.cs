using Akka.Actor;
using ConferenceSignalR.Akka.ActorModels.Messages;
using ConferenceSignalR.Akka.Web.Models;
using Microsoft.AspNetCore.SignalR;

namespace ConferenceSignalR.Akka.Web.ConferenceHubs
{
    public class ConferenceHub: Hub
    {
        ConferenceActorSystem _conferenceActorSystem;
        public ConferenceHub(ConferenceActorSystem conferenceActorSystem )
        {
            _conferenceActorSystem = conferenceActorSystem;
        }
        public void JoinConference(string userName)
        {

            _conferenceActorSystem.ActorReferences.SignalRBridge.Tell(new JoinConferenceRequest(userName));
            
        }

        public void CallConference(string userName)
        {

            _conferenceActorSystem.ActorReferences.SignalRBridge.Tell(new CallConferenceRequest(userName));

        }
    }
}
