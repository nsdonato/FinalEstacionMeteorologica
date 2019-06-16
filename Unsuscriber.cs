using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionMeteorologica
{
    public class Unsubscriber : IDisposable
    {
        private List<IObserver<Sensor>> _observers;
        private IObserver<Sensor> _observer;

        public Unsubscriber(List<IObserver<Sensor>> observers, IObserver<Sensor> observer)
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
