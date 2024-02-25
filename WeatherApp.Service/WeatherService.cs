using System;
using System.Threading.Tasks;

namespace WeatherApp.Service
{
    public class WeatherService
    {
        public Task RenderOutput()
        {
            Console.WriteLine("Hello World");
            return Task.CompletedTask;
        }
    }
}
