using System;
using System.Collections.Generic;

namespace WeatherStation.Api.Pattern
{
    public class Unsubscriber : IDisposable
    {
        private List<IObserver<WeatherData>> _observers;
        private IObserver<WeatherData> _observer;

        public Unsubscriber(List<IObserver<WeatherData>> observers, IObserver<WeatherData> observer)
        {
            this._observers = observers ?? throw new ArgumentNullException(nameof(observers));
            this._observer = observer  ?? throw new ArgumentNullException(nameof(observer));
        }

        public void Dispose()
            => _observers.Remove(_observer);
        
    }
}
