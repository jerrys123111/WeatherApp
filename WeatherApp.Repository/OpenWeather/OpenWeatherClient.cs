using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

using WeatherApp.Abstractions.Models;
using WeatherApp.Repository.Exceptions;
using WeatherApp.Repository.Models;

namespace WeatherApp.Repository.OpenWeather
{
    public class OpenWeatherClient
    {
        private readonly HttpClient _httpClient;
        public string _apiKey = "";
        public string _units = "";
        private readonly string _countryCode = "US";
        private readonly int _limit = 1;

        public OpenWeatherClient(HttpClient httpClient, OpenWeatherApiConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = configuration.Url;
            _apiKey = configuration.Key;
            _units = configuration.TemperatureUnits;
        }

        public async Task<IEnumerable<CoordinateResponse>> GetCoordinates(ILocation location)
        {
            var url = $"{_httpClient.BaseAddress}geo/1.0/direct?q={location.City},{location.State},{_countryCode}&limit={_limit}&appid={_apiKey}";

            Console.WriteLine("PREP QUERY");
            var response = await GetJsonAsAsync<List<CoordinateResponse>>(url);

            Console.WriteLine("MADE QUERY");

            return response;

        }

        public async Task<ForecastResponse> GetForecast(ICoordinate coordinate)
        {
            var url = $"{_httpClient.BaseAddress}data/2.5/forecast?lat={coordinate.Latitude}&lon={coordinate.Longitude}&units={_units}&appid={_apiKey}";

            var forecast = GetJsonAsAsync<ForecastResponse>(url);

            return await forecast;
        }

        public async Task<T> GetJsonAsAsync<T>(string url)
        {
            Console.WriteLine("QUERY ABOUT TO START");
            var response = await _httpClient.GetAsync(url);
            Console.WriteLine("QUERY CAME BACK");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("QUERY FAILED");
                throw new OpenWeatherException($"HTTP call not successful! HTTP Status Code: {response.StatusCode}: {response.ReasonPhrase}\n{response.Content}");
            }

            Console.WriteLine("QUERY WAS SUCCESS");
            var content = await response.Content.ReadFromJsonAsync<T>();
            return content;
        }
    }
}
