using System;
using System.Collections.Generic;
using System.Text;
using Akka.Actor;
using ConferenceSignalR.Akka.ActorModels.Messages;
using ConferenceSignalR.Akka.ActorModels.Models;

namespace ConferenceSignalR.Akka.ActorModels.Actors
{
    public class UserActor : ReceiveActor
    {
        public ConferenceUser _user;
        public string _message;
        public UserActor(ConferenceUser user)
        {
            _user = user;
         
            Receive<JoinConferenceRequest>(message =>
            {  
                Sender.Tell(new UserStatusChangedMessage(_user));
            });

            Receive<CallConferenceRequest>(message =>
            {
                Sender.Tell(new RefreshUserStatusMessage(_user));
            });

            Receive<RefreshUserStatusMessage>(message =>
            { 
                Sender.Tell(new UserStatusMessage(_user));
            });

          
        }
    }

    }
