using PlantDex.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantDex.Api.Services
{
    public class DateTimeService : IDateTimeService
    {
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
            throw new NotImplementedException();
        }

        public void setStandardFormat(string format)
        {
            throw new NotImplementedException();
        }
    }
}
