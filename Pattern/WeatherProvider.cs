using System;
using System.Collections.Generic;
using WeatherStation.Api.Exceptions;

namespace WeatherStation.Api.Pattern
{
    public class WeatherProvider : IObservable<WeatherData>
    {
        public IList<IObserver<WeatherData>> Observers {get ; private set;}

        public WeatherProvider()
            => Observers = new List<IObserver<WeatherData>>();
        

        public IDisposable Subscribe(IObserver<WeatherData> observer)
        {
            if (!Observers.Equals(observer))
                Observers.Add(observer);

            return new Unsubscriber(Observers, observer);
        }

        public void SetMeasurements(WeatherData weather)
        {
            foreach (var observer in Observers)
            {
                if (weather == null)
                    observer.OnError(new WeatherUnKnnowException());
                else
                    observer.OnNext(weather);
            }
        }
    }
}
