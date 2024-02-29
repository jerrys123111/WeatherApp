using WeatherApp.Abstractions.Models;

namespace WeatherApp.Abstractions
{
    /// <summary>
    /// Visual output of the weather report
    /// </summary>
    public interface IRenderOutput
    {
        /// <summary>
        /// Method to display the output of the weather report
        /// </summary>
        Task RenderOutput(IEnumerable<ILocation> locations);
    }
}
