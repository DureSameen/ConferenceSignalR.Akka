using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;
using ConferenceSignalR.Akka.ActorModels.Actors;
using ConferenceSignalR.Akka.ActorModels.ExternalSystems;
using ConferenceSignalR.Akka.Web.ConferenceHubs;
using Microsoft.AspNetCore.SignalR;
using static ConferenceSignalR.Akka.Web.Startup;

namespace ConferenceSignalR.Akka.Web.Models
{
    public    class ConferenceActorSystem
    {
        public   ActorReferences ActorReferences;
        public ConferenceActorSystem(ActorReferencesProvider provider)
        {
            ActorReferences = provider();

        }
        

    }

}