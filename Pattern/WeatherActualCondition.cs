using System;

namespace WeatherStation.Api.Pattern
{
    public class WeatherActualCondition : IObserver<WeatherData>
    {
        private IDisposable Unsubscriber;
        public WeatherData WeatherData { get; private set; }
        public string SensorName { get; }

        public WeatherActualCondition(string name)
        {
            this.SensorName = name;
        }

        public virtual void Subscribe(IObservable<WeatherData> provider)
        {
            Unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            Unsubscriber.Dispose();
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
            WeatherData = value;
        }
    }
}
