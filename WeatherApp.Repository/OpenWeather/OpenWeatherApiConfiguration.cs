namespace WeatherApp.Repository.OpenWeather
{
    public class OpenWeatherApiConfiguration
    {
        /// <summary>
        /// Base Address for the Open Weather API
        /// </summary>
        public Uri Url {  get; set; }
        /// <summary>
        /// Key needed to be authorized to retrieve data from the Open Weather API
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// The unit for temperature measurements for API endpoints in the Open Weather API
        /// </summary>
        public string TemperatureUnits { get; set; }

        public OpenWeatherApiConfiguration(string apiUrl, string apiKey, string apiTemperatureUnits)
        {
            Url = new Uri(apiUrl);
            Key = apiKey;
            TemperatureUnits = apiTemperatureUnits;
        }
    }
}
