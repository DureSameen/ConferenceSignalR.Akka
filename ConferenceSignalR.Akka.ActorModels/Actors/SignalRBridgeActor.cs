using System;
using System.Collections.Generic;
using System.Text;
using Akka.Actor;
using ConferenceSignalR.Akka.ActorModels.ExternalSystems;
using ConferenceSignalR.Akka.ActorModels.Messages;

namespace ConferenceSignalR.Akka.ActorModels.Actors
{ 
   public class SignalRBridgeActor:  ReceiveActor
    {
        private readonly IConferenceEventsPusher _conferenceEventsPusher;
        private readonly IActorRef _conferenceController;

        public SignalRBridgeActor(IConferenceEventsPusher  conferenceEventsPusher, IActorRef  conferenceController)
        {
            _conferenceEventsPusher = conferenceEventsPusher;
            _conferenceController = conferenceController;

            Receive<JoinConferenceRequest>(message => _conferenceController.Tell(message));
            Receive<CallConferenceRequest>(message => _conferenceController.Tell(message));
            Receive<UserStatusMessage>(message =>
            {
                _conferenceEventsPusher.UserJoined(message.User);
                
                });

            Receive<UserStatusChangedMessage>(message =>
            {
                _conferenceEventsPusher.UpdateUserStatus(message.User);

            });

        }


    }
}
