namespace WeatherApp.Abstractions.Models
{
    /// <summary>
    /// Interface representing a temperature
    /// </summary>
    public interface ITemperature
    {
        /// <summary>
        /// The unit of measurement for the temperature value
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// The temperature value
        /// </summary>
        public double Value { get; set; }
    }
}
