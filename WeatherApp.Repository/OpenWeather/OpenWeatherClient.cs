using System.Net.Http.Json;

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

        /// <summary>
        /// Retrieves the first set of coordinates for a given <see cref="ILocation"/>.
        /// Requires the API key and base address of the <see cref="HttpClient"/> to already be set.
        /// </summary>
        /// <remarks>
        /// <see href="https://openweathermap.org/api/geocoding-api#direct_name">Link to OpenWeather API documentation</see>
        /// </remarks>
        /// <param name="location">Location object to get coordinates for. This uses the city and state information.</param>
        /// <returns><see cref="Task{CoordinateResponse}"/></returns>
        public async Task<CoordinateResponse> GetCoordinates(ILocation location)
        {
            var url = $"{_httpClient.BaseAddress}geo/1.0/direct?q={location.City},{location.State},{_countryCode}&limit={_limit}&appid={_apiKey}";

            var response = await GetJsonAsAsync<IEnumerable<CoordinateResponse>>(url);

            var coordinate = response.FirstOrDefault();

            return coordinate;

        }

        /// <summary>
        /// Retrieves the 5 day weather forecast for a given coordinate.
        /// Requires the API key and base address of the <see cref="HttpClient"/> to already be set.
        /// </summary>
        /// <remarks>
        /// <see href="https://openweathermap.org/forecast5#5days">Link to OpenWeather API documentation</see>
        /// </remarks>
        /// <param name="coordinate">Coordinate object to get forecase information about.</param>
        /// <returns><see cref="Task{ForecastResponse}"/></returns>
        public async Task<ForecastResponse> GetForecast(ICoordinate coordinate)
        {
            var url = $"{_httpClient.BaseAddress}data/2.5/forecast?lat={coordinate.Latitude}&lon={coordinate.Longitude}&units={_units}&appid={_apiKey}";

            var forecast = await GetJsonAsAsync<ForecastResponse>(url);

            return forecast;
        }

        /// <summary>
        /// Helper method to make HTTP GET queries easier.
        /// Returns the HTTP Content as JSON mapped to a given object.
        /// </summary>
        /// <typeparam name="TResult">A generic class</typeparam>
        /// <param name="url">URL to HTTP endpoint, including base address and parameters</param>
        /// <returns><see cref="Task{TResult}"/></returns>
        /// <exception cref="OpenWeatherException"></exception>
        public async Task<TResult> GetJsonAsAsync<TResult>(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new OpenWeatherException($"HTTP call not successful! HTTP Status Code: {response.StatusCode}: {response.ReasonPhrase}\n{response.Content}");
            }

            try
            {
                var content = await response.Content.ReadFromJsonAsync<TResult>();

                return content == null ? throw new OpenWeatherException($"HTTP call succeeded but no content was returned!") : content;
            }
            catch (Exception ex)
            {

                throw new OpenWeatherException("Deserializing to JSON object failed!", ex.InnerException);
            }
        }
    }
}
