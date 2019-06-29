using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherStation.Api
{
    public class SimpleForecast 
    {
        private const string FORECAST_COLD_DAY = "Cloudy day with a chance of rain and afternoon rainfall.";
        private const string FORECAST_SUNNY_DAY = "Very sunny day, with little chance of rain and winds of 20km per hour.";

        public SimpleForecast(string temp, string hum, string pres, DateTime dateAndTime)
        {
            this.Temperature = temp;
            //this.HumActual = hum;
            //this.PresActual = pres;
            //this.DateActual = dateAndTime;
            this.Forecast = CalculateForecast();
        }

        public string CalculateForecast()
        {
            if (int.Parse(this.Temperature) > int.Parse("21"))
            {
                return FORECAST_SUNNY_DAY;
            }
            else
            {
                return FORECAST_COLD_DAY;
            }
        }

        public string Temperature { get; set; }
        //public string Humidity { get; set; }
        //public string PresActual { get; set; }
        //public DateTime Date { get; set; }
        public string Forecast { get; set; }
    }
}
