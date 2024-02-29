using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace WeatherApp.Repository.Models
{
    public class ForecastResponse
    {
        [JsonPropertyName("cnt")]
        public int CountOfTimestamps { get; set; }

        public List<string> ForecastList { get; set; }




    }
}
