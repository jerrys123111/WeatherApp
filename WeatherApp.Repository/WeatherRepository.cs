using System.Text;

using WeatherApp.Abstractions;
using WeatherApp.Abstractions.Models;
using WeatherApp.Repository.OpenWeather;

namespace WeatherApp.Repository
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly OpenWeatherClient _openWeatherClient;
        private readonly int _daysToCapture = 5;
        private readonly List<DayReport> _reports = new List<DayReport>();

        public WeatherRepository(OpenWeatherClient openWeatherClient)
        {
            _openWeatherClient = openWeatherClient;
        }

        public async Task<string> GenerateWeatherReport(ILocation location)
        {
            var weatherReport = new StringBuilder();

            //Retrieve coordinates to use for Forecast API call
            var coordinate = await _openWeatherClient.GetCoordinates(location);

            var forecast =  await _openWeatherClient.GetForecast(coordinate);

            //Add DateTime object in the response
            foreach (var dayResponse in forecast.ForecastList)
            {
                dayResponse.StandardTime = DateTime.Parse(dayResponse.UTCTime);
            }

            //Do some data cleaning. Remove entries for the current day and limit to only next 5 days.
            //Group the entries by Date and sort in ascending order.
            var filteredList = forecast.ForecastList
                .Where(day => day.StandardTime.Date != DateTime.Today && day.StandardTime.Date < DateTime.Today.AddDays(_daysToCapture + 1))
                .GroupBy(d => d.StandardTime.Date)
                .OrderBy(daylist => daylist.Key);

            foreach (var forecastDayResponse in filteredList)
            {
                List<double> temperatures = new List<double>();
                List<double> chanceOfPercipitation = new List<double>();

                foreach (var group in forecastDayResponse)
                {
                    temperatures.Add(group.MainTemperatureInfo.Value);
                    chanceOfPercipitation.Add(group.ProbabilityOfPrecipitation);

                }

                var averageTemp = temperatures.Average();
                var pop = chanceOfPercipitation.Any(num => num > 0);

                var createdDayReport = new DayReport(forecastDayResponse.Key, averageTemp, pop);

                _reports.Add(createdDayReport);

                weatherReport.AppendLine(createdDayReport.GenerateDayReport());

            }

            return weatherReport.ToString();
        }

    }
}
