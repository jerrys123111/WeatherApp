using System.Text.Json.Serialization;

namespace WeatherApp.Repository.Models
{
    public class ForecastResponse
    {
        [JsonPropertyName("cod")]
        public int Cod { get; set; }

        [JsonPropertyName("message")]
        public int Message { get; set; }

        [JsonPropertyName("cnt")]
        public int CountOfTimestamps { get; set; }

        [JsonPropertyName("list")]
        public required List<DayResponse> ForecastList { get; set; }


    }
}
