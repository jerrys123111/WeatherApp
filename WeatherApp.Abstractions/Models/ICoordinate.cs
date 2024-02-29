namespace WeatherApp.Abstractions.Models
{
    /// <summary>
    /// Interface representing a geographic coordinate
    /// </summary>
    public interface ICoordinate
    {
        /// <summary>
        /// A geographic latitude, in degrees
        /// </summary>
        double Latitude { get; set; }

        /// <summary>
        /// A geographic longitude, in degrees
        /// </summary>
        double Longitude { get; set; }
    }
}
