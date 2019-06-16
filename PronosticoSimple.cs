using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionMeteorologica.Api
{
    public class PronosticoSimple : WeatherData
    {
        public PronosticoSimple(decimal temp, decimal hum, double pres, DateTime dateAndTime)
            : base(temp, hum, pres, dateAndTime)
        {

        }

        private void CalcularPronostico()
        {
            //...
        }
    }
}
