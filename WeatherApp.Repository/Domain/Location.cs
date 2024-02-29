using WeatherApp.Abstractions.Models;

namespace WeatherApp.Repository.Domain
{
    /// <summary>
    /// Concrete implementation of a geographic location
    /// </summary>
    public class Location: ILocation
    {
        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public Location(string city, string state, string zipCode)
        {
            City = city;
            State = state;
            ZipCode = zipCode;
        }
    }
}
