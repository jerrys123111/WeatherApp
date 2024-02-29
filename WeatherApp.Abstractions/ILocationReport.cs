using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Abstractions
{
    public interface ILocationReport
    {
        /// <summary>
        /// Return the total list of reports for a given number of days.
        /// </summary>
        /// <param name="dayReports"></param>
        /// <returns></returns>
        public string GenerateLocationReport(IEnumerable<IDayReport> dayReports);
    }
}
