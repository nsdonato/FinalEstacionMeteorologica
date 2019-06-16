using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionMeteorologica.Api
{
    public class WeatherSubscriber : IObservable<WeatherData>
    {
        public List<IObserver<WeatherData>> observers;

        public WeatherSubscriber()
        {
            observers = new List<IObserver<WeatherData>>();
        }

        public IDisposable Subscribe(IObserver<WeatherData> observer)
        {
            if (!observers.Contains(observer))
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
