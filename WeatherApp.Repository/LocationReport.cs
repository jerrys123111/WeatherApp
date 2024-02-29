using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WeatherApp.Abstractions;

namespace WeatherApp.Repository
{
    public class LocationReport: ILocationReport
    {
        public string GenerateLocationReport(IEnumerable<IDayReport> dayReports)
        {
            var stringBuilder = new StringBuilder();


            foreach (var dayReport in dayReports)
            {
                stringBuilder.AppendLine(dayReport.GenerateDayReport());
            }

            stringBuilder.AppendLine();

            return stringBuilder.ToString();
        }
    }
}
