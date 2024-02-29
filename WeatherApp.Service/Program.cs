using System;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using WeatherApp.Abstractions;
using WeatherApp.Repository;
using WeatherApp.Repository.Domain;
using WeatherApp.Repository.OpenWeather;
using WeatherApp.Service;

public class Program
{
    /// <summary>
    /// Main method called by runtime at application startup time.
    /// The list of locations is hardcoded in here, but ideally would be passed in
    /// either as configuration values or input parameters.
    /// </summary>
	public static void Main(string[] args)
	{

        var host = CreateBuilder(args);

        //This data could be grabbed ideally from another source, like a config file or a database.
        var locations = new List<Location>()
        {
            new Location("Marlboro", "MA", "01752"),
            new Location("San Diego", "CA", "92101"),
            new Location("Cheyenne", "WY", "82001"),
            new Location("Anchorage", "AK", "99501"),
            new Location("Austin", "TX", "78701"),
            new Location("Orlando", "FL", "32801"),
            new Location("Seattle", "WA", "98101"),
            new Location("Cleveland", "OH", "44113"),
            new Location("Portland", "ME", "04101"),
            new Location("Honolulu", "HI", "96813")
        };

        var weatherService = host.Services.GetRequiredService<IRenderOutput>();

        weatherService.RenderOutput(locations);

	}

    /// <summary>
    /// Initializes a static host to be executed.
    /// This adds all the services and other information for the application to start up.
    /// </summary>
    /// <param name="args">Configuration settings for the <see cref="IHostApplicationBuilder"/></param>
    /// <returns><see cref="IHost"/></returns>
    public static IHost CreateBuilder(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);

        var apiUrl = "https://api.openweathermap.org";
        //var apiKey = builder.Configuration["OpenWeatherApiKey"];

        builder.Services.AddHttpClient<OpenWeatherClient>(client => client.BaseAddress = new Uri(apiUrl));
        builder.Services.AddSingleton<IWeatherRepository, WeatherRepository>();
        builder.Services.AddSingleton<IRenderOutput, WeatherConsoleOutput>();

        builder.Metrics.Services.AddMetrics();

        return builder.Build();
    }
    
}