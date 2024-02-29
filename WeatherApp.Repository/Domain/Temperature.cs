using System.ComponentModel;
using System.Text.Json.Serialization;

using WeatherApp.Abstractions.Models;

namespace WeatherApp.Repository.Domain
{
    /// <summary>
    /// Concrete implementation of a temperature
    /// </summary>
    public class Temperature: ITemperature
    {
        [DefaultValue("F")]
        public string Unit { get; set; }

        [JsonPropertyName("temp")]
        public double Value { get; set; }

        public Temperature(string  unit, double value)
        {
            Unit = unit;
            Value = value;
        }

    }
}
