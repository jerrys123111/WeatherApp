using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

using WeatherApp.Abstractions.Models;
using WeatherApp.Repository.Models;

namespace WeatherApp.Repository.OpenWeather
{
    public class OpenWeatherClient
    {
        private readonly HttpClient _httpClient;
        public string _apiKey = "50e0d7799ca09ef508d2b1df4d413319";
        private readonly string _countryCode = "US";
        private readonly int _limit = 1;

        public OpenWeatherClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CoordinateResponse> GetCoordinates(ILocation location)
        {
            var url = $"{_httpClient.BaseAddress}geo/1.0/direct?q={location.City},{location.State},{_countryCode}&limit={_limit}&appid={_apiKey}";

            var response = await _httpClient.GetAsync(url);

            var content = response.Content.ReadFromJsonAsync<CoordinateResponse>();

            return await content;

        }

        public async Task<ForecastResponse> GetForecast(ICoordinate coordinate)
        {
            var url = $"{_httpClient.BaseAddress}data/2.5/forecast?lat={coordinate.Latitude}&lon={coordinate.Longitude}&appid={_apiKey}";

            var result = await _httpClient.GetAsync(url);

            var forecast = result.Content.ReadFromJsonAsync<ForecastResponse>();

            return await forecast;
        }

    }
}
