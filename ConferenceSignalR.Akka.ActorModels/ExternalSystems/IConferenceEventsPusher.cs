using ConferenceSignalR.Akka.ActorModels.Models;

namespace ConferenceSignalR.Akka.ActorModels.ExternalSystems
{
    public interface IConferenceEventsPusher
    {
       void UserJoined(ConferenceUser user);
       void UpdateUserStatus(ConferenceUser user);
    }
}
