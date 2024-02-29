using System.Reflection;

using WeatherApp.Abstractions;
using WeatherApp.Abstractions.Models;
using WeatherApp.Repository.OpenWeather;

namespace WeatherApp.Repository
{
    public class WeatherRepository : IWeatherRepository
    {
        private OpenWeatherClient _openWeatherClient;
        private readonly string units = "Imperial";
        private readonly int _daysToCapture = 5;

        public string apiKey { get; set; }

        public WeatherRepository(OpenWeatherClient openWeatherClient)
        {
            _openWeatherClient = openWeatherClient;
        }

        public void RunRepository()
        {

        }

        public async void GenerateWeatherReport(ILocation location)
        {

            var coordinates = _openWeatherClient.GetCoordinates(location);

            var content = await coordinates;

            Console.WriteLine("Latitude: {0}\tLongitude: {1}", content.Latitude, content.Longitude);



            
        }
    }
}
