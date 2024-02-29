using System.Reflection;
using System.Text;

using WeatherApp.Abstractions;
using WeatherApp.Abstractions.Models;
using WeatherApp.Repository.Domain;
using WeatherApp.Repository.OpenWeather;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeatherApp.Repository
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly OpenWeatherClient _openWeatherClient;
        private readonly int _daysToCapture = 5;
        private List<IDayReport> _reports;

        public WeatherRepository(OpenWeatherClient openWeatherClient)
        {
            _openWeatherClient = openWeatherClient;
        }

        public async Task<string> GenerateWeatherReport(ILocation location)
        {
            var stringBuilder = new StringBuilder();

            Console.WriteLine("START HERE");
            var coordinates = await _openWeatherClient.GetCoordinates(location);

            Console.WriteLine("RETRIEVED COORDS");

            var finalCoordinate = coordinates.FirstOrDefault();

            Console.WriteLine("RETRIEVED FIRST COORDS");

            foreach ( var coordinate in coordinates)
            {
                stringBuilder.AppendLine($"Name: {coordinate.Name}\tLatitude: {coordinate.Latitude}\tLongitude: {coordinate.Longitude}");
            }

            //foreach (var dayReport in _reports)
            //{
            //    stringBuilder.AppendLine(dayReport.GenerateDayReport());
            //}

            return stringBuilder.ToString();
        }

        public async Task<string> RetrieveForecastData()
        {
            var stringBuilder = new StringBuilder();





            return string.Empty;
        }

    }
}
