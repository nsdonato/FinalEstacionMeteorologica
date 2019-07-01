using System;

namespace WeatherStation.Api.Pattern
{
    public class WeatherSimpleForecast : IObserver<WeatherData>
    {
        private const string FORECAST_COLD_DAY = "Cloudy day with a chance of rain and afternoon rainfall.";
        private const string FORECAST_SUNNY_DAY = "Very sunny day, with little chance of rain and winds of 20km per hour.";

        private IDisposable _unsubscriber;
        public string SensorName { get; private set; }
        public decimal Temperature { get; set; }
        public string Forecast { get; set; }
        public bool IsSuscribed { get; set; }

        public WeatherSimpleForecast(string name)
        {
            SensorName = name;
        }

        public virtual void Subscribe(IObservable<WeatherData> provider)
        {
            IsSuscribed = true;
            _unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            IsSuscribed = false;
            _unsubscriber.Dispose();
        }

        public virtual void OnCompleted()
        {
            IsSuscribed = false;
            Unsubscribe();
        }

        public virtual void OnError(Exception error)
        {
            Console.WriteLine("{0}: The provider cannot be read data.", SensorName);
        }

        public virtual void OnNext(WeatherData value)
        {
            Temperature = value.Temp;
            Forecast = CalculateForecast();
        }

        public string CalculateForecast()
        {
            if (Temperature > 21)
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
