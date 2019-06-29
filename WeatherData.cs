using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherStation.Api
{
    public class WeatherData
    {
        public string Temp { get; private set; }
        public string Hum { get; private set; }
        public string Pres { get; private set; }

        public DateTime Date { get; private set; }

        public WeatherData(decimal temp, decimal hum, double pres, DateTime dateAndTime)
        {
            Temp = decimal.Round(temp).ToString();
            Hum = hum.ToString("N2");
            Pres = pres.ToString("N3");
            Date = dateAndTime;
        }
    }
}
