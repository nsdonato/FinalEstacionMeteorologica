using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherStation.Api.Pattern
{
    public class WeatherStatistics : IObserver<WeatherData>
    {
        private IDisposable unsubscriber;
        public List<WeatherData> ListWeatherData = new List<WeatherData>();
        public decimal MediumTemperature { get; private set; }
        public decimal MaximumTemperature { get; }
        public string Information { get; private set; }
        public string SensorName { get; }

        public WeatherStatistics(string name)
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
            ListWeatherData.Add(value);
            this.ListWeatherData.Take(5);

            if (ListWeatherData.Count > 1)
            {
                var maxTemp = ListWeatherData.Select(c => c.Temp).Max();
                var minTemp = ListWeatherData.Select(c => c.Temp).Min();
                this.MediumTemperature = ((maxTemp + minTemp) / 2);
                this.Information = $"The average temperature is: {this.MediumTemperature}";
            }

            this.Information = "The average temperature will be available in minutes. ";
        }
    }
}
