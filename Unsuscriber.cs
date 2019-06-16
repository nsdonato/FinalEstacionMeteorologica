using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionMeteorologica.Api
{
    public class Unsubscriber : IDisposable
    {
        private List<IObserver<WeatherData>> _observers;
        private IObserver<WeatherData> _observer;

        public Unsubscriber(List<IObserver<WeatherData>> observers, IObserver<WeatherData> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (!(_observer == null)) _observers.Remove(_observer);
        }
    }
}
