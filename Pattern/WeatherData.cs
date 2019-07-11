using System;

namespace WeatherStation.Api.Pattern
{
    public class WeatherData 
    {
        public decimal Temp { get; } //no abreviar, no es claro.
        public decimal Hum { get; }
        public decimal Pres { get; }

        public DateTime Date { get; }

        public WeatherData(decimal temp, decimal hum, double pres, DateTime dateAndTime)
        {
            Temp = decimal.Round(temp);
            Hum = decimal.Parse(hum.ToString("N2"));
            Pres = decimal.Parse(pres.ToString("N3"));
            Date = dateAndTime;
        }

    }
}
