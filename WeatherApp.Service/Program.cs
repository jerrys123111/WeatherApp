using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    /// <summary>
    /// Main method called by runtime at application startup time.
    /// </summary>
	public static void Main(string[] args)
	{

        var host = CreateBuilder(args);

        host.Run();

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

        builder.Services.AddHttpClient();
        builder.Metrics.Services.AddMetrics();

        return builder.Build();
    }
    
}