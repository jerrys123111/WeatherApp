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

        public DayReport() {

        }

        public ITemperature AverageTemperature()
        {
            throw new NotImplementedException();
        }

        public DateTime GetDate()
        {
            throw new NotImplementedException();
        }

        public bool IsPrecipitationLikely()
        {
            throw new NotImplementedException();
        }

        public string GenerateDayReport()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(GetDate().ToString("MM/dd/yyyy"));

            if (IsPrecipitationLikely())
            {
                stringBuilder.Append("*\t");
            }
            else stringBuilder.Append('\t');

            stringBuilder.Append($"{AverageTemperature().Value}  {AverageTemperature().Unit}");

            return stringBuilder.ToString();
        }
    }
}
