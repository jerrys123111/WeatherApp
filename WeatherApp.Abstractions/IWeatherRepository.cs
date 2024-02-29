using WeatherApp.Abstractions.Models;

namespace WeatherApp.Abstractions
{
    public interface IWeatherRepository
    {
        public string apiKey { get; set; }
        public void GenerateWeatherReport(ILocation location);
    }
}
