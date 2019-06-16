using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionMeteorologica.Api
{
    public class CondicionesActuales : WeatherData
    {
        public CondicionesActuales(decimal temp, decimal hum, double pres, DateTime dateAndTime) : base(temp, hum, pres, dateAndTime)
        {
            //tempActual = temp;
            //humActual = hum;
            //presActual = pres;
            //dateActual = dateAndTime;
        }

        //public decimal tempActual { get; set; }
        //public decimal humActual { get; set; }
        //public double presActual { get; set; }
        //public DateTime dateActual { get; set; }
    }
}
