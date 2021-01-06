using PlantDex.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantDex.Api.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTimeService()
        {
            this.standardFormat = "yyyy-MM-dd HH:mm";
            this.timezone = "UTC+08:00";
        }

        public string standardFormat { get; private set; }

        public string uiFormat { get; private set; }

        public string timezone { get; private set; }

        public DateTime format(string dateTime, string format, string timezone)
        {
            throw new NotImplementedException();
        }

        public DateTime format(DateTime original, string timezone)
        {
            throw new NotImplementedException();
        }

        public DateTime getCurrentDate()
        {
            return DateTime.Now;
        }
    }
}
