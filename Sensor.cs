using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionMeteorologica
{
    public class Sensor
    {
        public decimal temp { get; private set; }
        public decimal hum { get; private set; }
        public double pres { get; private set; }
        public DateTime Date { get; private set; }

        public Sensor(decimal temp, decimal hum, double pres, DateTime dateAndTime)
        {
            this.temp = temp;
            this.hum = hum;
            this.pres = pres;
            this.Date = dateAndTime;
        }
    }
}
