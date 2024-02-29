using WeatherApp.Abstractions.Models;

namespace WeatherApp.Abstractions
{
    public interface IDayReport
    {
        public DateTime Date { get; set; }

        public ITemperature AverageTemperature {  get; set; }

        public bool IsPrecipitationLikely();

        /// <summary>
        /// Returns the report for a given day.
        /// </summary>
        /// <returns></returns>
        public string GenerateDayReport();
    }
}
