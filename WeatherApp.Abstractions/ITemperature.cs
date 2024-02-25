namespace WeatherApp.Abstractions
{
    public interface ITemperature
    {
        public string Unit { get; set; }
        public double Value { get; set; }
        public double ConvertTo(string unit);
    }
}
