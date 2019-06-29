using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherStation.Api
{
    public class WeatherStatistics : IObserver<WeatherData>
    {
        private IDisposable unsubscriber;
        public List<WeatherData> WeatherData = new List<WeatherData>();
        public string SensorName { get; private set; }

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
            WeatherData.Add(value);
        }

    }
}
