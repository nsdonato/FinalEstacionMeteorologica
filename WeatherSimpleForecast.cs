using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherStation.Api
{
    public class WeatherSimpleForecast : IObserver<WeatherData>
    {
        private const string FORECAST_COLD_DAY = "Cloudy day with a chance of rain and afternoon rainfall.";
        private const string FORECAST_SUNNY_DAY = "Very sunny day, with little chance of rain and winds of 20km per hour.";

        private IDisposable unsubscriber;
        public string SensorName { get; private set; }
        public string Temperature { get; set; }
        public string Forecast { get; set; }

        public WeatherSimpleForecast(string name)
        {
            this.SensorName = name;
        }

        public virtual void Subscribe(IObservable<WeatherData> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public virtual void OnCompleted()
        {
            this.Unsubscribe();
        }

        public virtual void OnError(Exception error)
        {
            Console.WriteLine("{0}: The provider cannot be read data.", this.SensorName);
        }

        public virtual void OnNext(WeatherData value)
        {
            this.Temperature = value.Temp;
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
    }
}
