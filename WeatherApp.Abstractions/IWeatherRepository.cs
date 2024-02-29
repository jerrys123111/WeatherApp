using WeatherApp.Abstractions.Models;

namespace WeatherApp.Abstractions
{
    public interface IWeatherRepository
    {
        /// <summary>
        /// Return the weather forecast report for a given location.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public Task<string> GenerateWeatherReport(ILocation location);
    }
}
