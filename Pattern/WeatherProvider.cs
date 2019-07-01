using System;
using System.Collections.Generic;
using WeatherStation.Api.Exceptions;

namespace WeatherStation.Api.Pattern
{
    public class WeatherProvider : IObservable<WeatherData>
    {
        public List<IObserver<WeatherData>> observers;

        public WeatherProvider()
        {
            observers = new List<IObserver<WeatherData>>();
        }

        public IDisposable Subscribe(IObserver<WeatherData> observer)
        {
            if (!observers.Equals(observer))
                observers.Add(observer);

            return new Unsubscriber(observers, observer);
        }

        public void SetMeasurements(WeatherData weather)
        {
            foreach (var observer in observers)
            {
                if (weather == null)
                    observer.OnError(new WeatherUnKnnowException());
                else
                    observer.OnNext(weather);
            }
        }
    }
}
