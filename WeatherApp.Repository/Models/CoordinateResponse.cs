using System.Text.Json.Serialization;

using WeatherApp.Abstractions.Models;

namespace WeatherApp.Repository.Models
{
    /// <summary>
    /// Concrete implementation of a geographic coordinate, in degrees
    /// </summary>
    public class CoordinateResponse : ICoordinate
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
    }
}
