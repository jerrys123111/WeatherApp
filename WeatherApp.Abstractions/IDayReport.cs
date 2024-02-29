namespace WeatherApp.Abstractions
{
    public interface IDayReport
    {
        /// <summary>
        /// Returns <see cref="DateTime"/> for a given day.
        /// </summary>
        public DateTime Day { get; set; }

        /// <summary>
        /// Returns the average temperature for a given day.
        /// </summary>
        public double AverageTemperature {  get; set; }

        /// <summary>
        /// Returns whether there is a chance of precipitation for a given day.
        /// </summary>
        /// <returns><see cref="bool"/></returns>
        public bool IsPrecipitationLikely();

        /// <summary>
        /// Returns the report for a given day.
        /// </summary>
        /// <returns></returns>
        public string GenerateDayReport();
    }
}
