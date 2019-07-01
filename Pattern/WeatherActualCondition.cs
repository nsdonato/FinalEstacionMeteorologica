using System;

namespace WeatherStation.Api.Pattern
{
    public class WeatherActualCondition : IObserver<WeatherData>
    {
        private IDisposable _unsubscriber;
        public WeatherData WeatherData { get; private set; }
        public string SensorName { get; }
        public bool IsSuscribed { get; set; }

        public WeatherActualCondition(string name)
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
            //IsSuscribed = false;
            _unsubscriber.Dispose();
        }

        public virtual void OnCompleted()
        {
            //IsSuscribed = false;
            Unsubscribe();
        }

        public virtual void OnError(Exception error)
        {
            Console.WriteLine("{0}: The provider cannot be read data.", SensorName);
        }

        public virtual void OnNext(WeatherData value)
        {
            WeatherData = value;
        }
    }
}
