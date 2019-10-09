using System.Collections.Generic;
using Akka.Actor;
using ConferenceSignalR.Akka.ActorModels.Messages;

namespace ConferenceSignalR.Akka.ActorModels.Actors
{
    public class ConferenceControllerActor : ReceiveActor
    {

        private readonly Dictionary<string, IActorRef> _users;

        public ConferenceControllerActor()
        {
            _users = new Dictionary<string, IActorRef>();

            Receive<JoinConferenceRequest>(message => Join(message));
        }

        private void Join(JoinConferenceRequest message)
        {
            bool userNeedsCreation = !_users.ContainsKey(message.User.UserName);

            if (userNeedsCreation)
            {
                IActorRef newConferenceUser = Context.ActorOf(Props.Create(() => new UserActor(message.User)), message.User.UserName);
                _users.Add(message.User.UserName, newConferenceUser); 
                foreach (var user in _users.Values)
                    
                    user.Tell(new RefreshUserStatusMessage(message.User), Sender);
            }
        }
    }
}