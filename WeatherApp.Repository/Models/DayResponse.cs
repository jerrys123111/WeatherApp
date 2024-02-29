using System.Text.Json.Serialization;

using WeatherApp.Repository.Domain;

namespace WeatherApp.Repository.Models
{
    public class DayResponse
    {
        [JsonPropertyName("dt")]
        public double UnixTime { get; set; }

        [JsonPropertyName("main")]
        public required Temperature MainTemperatureInfo { get; set; }

        [JsonPropertyName("pop")]
        public double ProbabilityOfPrecipitation { get; set; }
        
        [JsonPropertyName("dt_txt")]
        public required string UTCTime { get; set; }
        
        public DateTime StandardTime { get; set; }
    }
}
