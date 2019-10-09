using System;
using System.Collections.Generic;
using System.Text;
using ConferenceSignalR.Akka.ActorModels.Models;

namespace ConferenceSignalR.Akka.ActorModels.Messages
{
    public class UserStatusChangedMessage
    {
        public ConferenceUser User { get;   set; }
        public UserStatusChangedMessage(ConferenceUser user)
        {
            User = user;
        }
    }
}
