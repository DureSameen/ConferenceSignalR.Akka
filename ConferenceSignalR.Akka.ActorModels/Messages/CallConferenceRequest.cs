using System;
using System.Collections.Generic;
using System.Text;
using ConferenceSignalR.Akka.ActorModels.Models;

namespace ConferenceSignalR.Akka.ActorModels.Messages
{
   public class CallConferenceRequest
    {

        
        public string Attendee { get; set; }

        public CallConferenceRequest(string attendee)
        {
           
            Attendee = attendee;
        }
    }
}
