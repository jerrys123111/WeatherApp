using System.Text;

using WeatherApp.Abstractions;

namespace WeatherApp.Repository
{
    public class DayReport : IDayReport
    {
        public DateTime Day { get; set; }

        public bool ProbabilityOfPrecipitation { get; set; }

        public double AverageTemperature { get; set; }

        public DayReport(DateTime dateTime, double temperature, bool chanceOfPrecipitation) {
            Day = dateTime;
            AverageTemperature = temperature;
            ProbabilityOfPrecipitation = chanceOfPrecipitation;
        }

        public bool IsPrecipitationLikely()
        {
            return ProbabilityOfPrecipitation;
        }

        public string GenerateDayReport()
        {
            var stringBuilder = new StringBuilder();
            
            stringBuilder.Append($"{Day.ToString("MM/dd/yyyy")}"); 

            var chanceOfPrecipitation = IsPrecipitationLikely() ? "*\t" : "\t";
            stringBuilder.Append(chanceOfPrecipitation);

            //Format string to 2 decimal places.
            stringBuilder.Append($"{AverageTemperature:N2}\tF");

            return stringBuilder.ToString();
        }
    }
}
