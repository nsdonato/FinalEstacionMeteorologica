using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherStation.Api
{
    public class CurrentConditions 
    {
        public CurrentConditions(string temp, string hum, string pres, DateTime dateAndTime)
        {
            CurrentTemp = temp;
            CurrentHum = hum;
            CurrentPress = pres;
            CurrentDate = dateAndTime;
        }

        public string CurrentTemp { get; set; }
        public string CurrentHum { get; set; }
        public string CurrentPress { get; set; }
        public DateTime CurrentDate { get; set; }
    }
}
