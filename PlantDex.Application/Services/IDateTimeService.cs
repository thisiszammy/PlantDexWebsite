using System;
using System.Collections.Generic;
using System.Text;

namespace PlantDex.Application.Services
{
    public interface IDateTimeService
    {
        public DateTime getCurrentDate();
        public DateTime format(string dateTime, string format, string timezone);
        public DateTime format(DateTime original, string timezone);
        public void setStandardFormat(string format);
    }
}
