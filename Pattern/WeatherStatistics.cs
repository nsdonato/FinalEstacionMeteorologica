using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherStation.Api.Pattern
{
    public class WeatherStatistics : IObserver<WeatherData>
    {
        private IDisposable _unsubscriber;
        public List<WeatherData> ListWeatherData = new List<WeatherData>();
        public List<WeatherData> LastData = new List<WeatherData>();
        public decimal MediumTemperature { get; private set; }
        public decimal MinimumTemperature { get; private set; }
        public decimal MaximumTemperature { get; private set; }
        public string Information { get; private set; }
        public string SensorName { get; }
        public bool IsSuscribed { get; set; }
       

        public WeatherStatistics(string name)
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
            ListWeatherData.Add(value);
            LastData = ListWeatherData.TakeLast(5).ToList();
            MinimumTemperature = ListWeatherData.Select(c => c.Temp).Min();
            MaximumTemperature = ListWeatherData.Select(c => c.Temp).Max();

            if (ListWeatherData.Count > 1)
            {
                MediumTemperature = ((ListWeatherData.Select(c => c.Temp).Max() + ListWeatherData.Select(c => c.Temp).Min()) / 2);
                Information = $"The average temperature is: {MediumTemperature}";
            }
            else
            {
                Information = "The average temperature will be available in minutes. ";
            }
        }
    }
}
