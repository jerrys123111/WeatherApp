using WeatherApp.Abstractions.Models;

namespace WeatherApp.Abstractions
{
    public interface IDayReport
    {
        public DateTime GetDate();

        public bool IsPrecipitationLikely();

        public ITemperature AverageTemperature();

        /// <summary>
        /// Returns the report for a given day.
        /// </summary>
        /// <returns></returns>
        public string GenerateDayReport();
    }
}
