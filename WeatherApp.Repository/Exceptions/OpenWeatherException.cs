using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Repository.Exceptions
{
    /// <summary>
    /// Class to have custom error message for exceptions thrown
    /// when using the Open Weather API.
    /// </summary>
    public class OpenWeatherException: Exception
    {
        public OpenWeatherException(string message, Exception? innerException = null) { 
            if(innerException != null)
            {
                throw new Exception(message, innerException);
            }
            else throw new Exception(message);
        }
    }
}
