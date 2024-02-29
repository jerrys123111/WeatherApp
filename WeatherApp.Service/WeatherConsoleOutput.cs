using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using WeatherApp.Abstractions;
using WeatherApp.Abstractions.Models;

namespace WeatherApp.Service
{
    /// <summary>
    /// Concrete implementation of rendering the weather report.
    /// This will render the output to the console.
    /// </summary>
    public class WeatherConsoleOutput: IRenderOutput
    {
        private readonly IConfiguration _configuration;
        private readonly IWeatherRepository _weatherRepository;

        public WeatherConsoleOutput(IWeatherRepository weatherRepository, IConfiguration configuration)
        {
            _configuration = configuration;
            _weatherRepository = weatherRepository;
            _weatherRepository.apiKey = configuration["OpenWeatherApiKey"];
        }

        public async void RenderOutput(IEnumerable<ILocation> locations)
        {
            Console.WriteLine(_configuration.ToString());

            foreach (var location in locations)
            {
                Console.WriteLine("______________________________");

                Console.WriteLine($"{location.City}, {location.State} ({location.ZipCode})");

                Console.WriteLine("Date\tAvg Temp (F)");

                Console.WriteLine("------------------------------");


                //var locationReport = await
                    _weatherRepository.GenerateWeatherReport(location);
                //Console.WriteLine(locationReport.ToString());

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
