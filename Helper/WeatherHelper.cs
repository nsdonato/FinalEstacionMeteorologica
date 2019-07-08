using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherStation.Api.Helper
{
    public static class WeatherHelper
    {
        private static readonly Random random = new Random();
        public static decimal GetTemperature()
        {
            return decimal.Parse(RandomTemperatureBetween(0.0, 50.0).ToString());
        }
        public static int GetHumidity()
        {
            return RandomHumidityBetween(100);
        }
        public static double GetPressure()
        {
            return RandomPressureBetween(1.0, 1.000);
        }
        private static double RandomTemperatureBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();
            return minValue + (next * (maxValue - minValue));
        }
        private static int RandomHumidityBetween(int maxValue)
        {
            var next = random.Next(maxValue);
            return next;
        }
        private static double RandomPressureBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();
            return minValue + (next * (maxValue - minValue));
        }
    }
}
