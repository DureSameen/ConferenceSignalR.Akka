using System.Collections.Generic;
using ConferenceSignalR.Akka.Data.Models;

namespace ConferenceSignalR.Akka.Data.Repositories
{
    public interface IWeatherForecastRepository
    {
        IEnumerable<WeatherForecast> GetForecast();
    }
}