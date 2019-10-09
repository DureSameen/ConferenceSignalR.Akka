using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceSignalR.Akka.ActorModels.Models
{
    public class ConferenceUser
    {

        public string UserName { get;   set; }  
        public UserStatus Status { get;   set; }
         
        public ConferenceUser(string userName, UserStatus status)
        {
            UserName = userName;
            Status = status;
        }
    }
}
