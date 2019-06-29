using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherStation.Api.Helper
{
    public static class WeatherHelper
    {
        public static decimal getTemperature()
        {
            var rand = new Random();
            return (decimal)rand.NextDouble(); ;
        }

        public static decimal getHumidity()
        {
            var rand = new Random();
            return (decimal)rand.NextDouble(); ;
        }

        public static double getPressure()
        {
            var rand = new Random();
            return rand.NextDouble(); 
        }
    }
}
