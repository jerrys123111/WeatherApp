using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WeatherApp.Abstractions;
using WeatherApp.Abstractions.Models;
using WeatherApp.Repository.OpenWeather;

namespace WeatherApp.Service
{
    /// <summary>
    /// Concrete implementation of rendering the weather report.
    /// This will render the output to the console.
    /// </summary>
    public class WeatherConsoleOutput: IRenderOutput
    {
        private readonly OpenWeatherApiConfiguration _configuration;
        private readonly IWeatherRepository _weatherRepository;

        public WeatherConsoleOutput(IWeatherRepository weatherRepository, OpenWeatherApiConfiguration configuration)
        {
            _configuration = configuration;
            _weatherRepository = weatherRepository;
        }

        public async Task RenderOutput(IEnumerable<ILocation> locations)
        {
            Console.WriteLine("API Key: " + _configuration.Key);

            //Creates task for each given location to run in parallel
            var locationReports = await Task.WhenAll(locations.Select(location => GenerateLocationReport(location)));

            foreach (var location in locations)
            {
                Console.WriteLine(await GenerateLocationReport(location));
            }
        }

        public async Task<string> GenerateLocationReport(ILocation location)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("______________________________");
            stringBuilder.AppendLine($"{location.City}, {location.State} ({location.ZipCode})");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("Date\tAvg Temp (F)");
            stringBuilder.AppendLine("------------------------------");

            var locationReport = await _weatherRepository.GenerateWeatherReport(location);
            stringBuilder.AppendLine(locationReport);

            stringBuilder.AppendLine();
            stringBuilder.AppendLine();

            return stringBuilder.ToString();
        }


    }
}
