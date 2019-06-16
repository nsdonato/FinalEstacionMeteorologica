using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionMeteorologica.Api
{
    public class WeatherData
    {
        public decimal Temp { get; private set; }
        public decimal Hum { get; private set; }
        public double Pres { get; private set; }

        public DateTime Date { get; private set; }

        public WeatherData(decimal temp, decimal hum, double pres, DateTime dateAndTime)
        {
            this.Temp = temp;
            this.Hum = hum;
            this.Pres = pres;
            this.Date = dateAndTime;
        }
    }
}
