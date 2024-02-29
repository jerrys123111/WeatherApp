using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WeatherApp.Abstractions;
using WeatherApp.Abstractions.Models;

namespace WeatherApp.Repository
{
    public class DayReport : IDayReport
    {
        public DateTime Date { get; set; }
        public ITemperature AverageTemperature { get; set; }

        public DayReport() {

        }

        public bool IsPrecipitationLikely()
        {
            throw new NotImplementedException();
        }

        public string GenerateDayReport()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(Date.ToString("MM/dd/yyyy"));

            var chanceOfPrecipitation = IsPrecipitationLikely() ? "*\t" : "\t";
            stringBuilder.Append(chanceOfPrecipitation);

            stringBuilder.Append($"{AverageTemperature.Value}  {AverageTemperature.Unit}");

            return stringBuilder.ToString();
        }
    }
}
