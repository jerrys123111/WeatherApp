using WeatherApp.Abstractions.Models;

namespace WeatherApp.Repository.Domain
{
    /// <summary>
    /// Concrete implementation of a temperature
    /// </summary>
    public class Temperature: ITemperature
    {
        public string Unit { get; set; }
        public double Value { get; set; }

        public Temperature(string  unit, double value)
        {
            Unit = unit;
            Value = value;
        }

    }
}
