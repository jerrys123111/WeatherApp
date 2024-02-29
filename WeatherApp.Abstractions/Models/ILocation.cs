namespace WeatherApp.Abstractions.Models
{
    /// <summary>
    /// Interface representing a geographic location
    /// </summary>
    public interface ILocation
    {
        /// <summary>
        /// A city/town in a country
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The state for a given city, if applicable
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The zip code for a given city, if applicable
        /// </summary>
        public string ZipCode { get; set; }
    }
}
