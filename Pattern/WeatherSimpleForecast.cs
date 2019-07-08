using System;

namespace WeatherStation.Api.Pattern
{
    public class WeatherSimpleForecast : IObserver<WeatherData>
    {
        private const string FORECAST_COLD_DAY = 
            "Cloudy day, with low temperature and rain probability. In " +
            "the afternoon the humidity will increase and the pressure " +
            "will be stable. Rains are expected at night.";
        private const string FORECAST_SUNNY_DAY = 
            "Very sunny day, with a bit of cloudiness in the afternoon " +
            "and increased pressure. At night a clear " +
            "sky and a drop in temperature are expected.";

        private IDisposable _unsubscriber;
        public string SensorName { get; private set; }
        public decimal Temperature { get; set; }
        public string Forecast { get; set; }
        public bool IsSuscribed { get; set; }
        public bool IsSunny { get; private set; }

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
                IsSunny = true;
                return FORECAST_SUNNY_DAY;
            }
            else
            {
                IsSunny = false;
                return FORECAST_COLD_DAY;
            }
        }
    }
}
