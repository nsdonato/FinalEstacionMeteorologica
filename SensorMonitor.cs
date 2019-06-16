using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionMeteorologica
{
    public class SensorMonitor : IObservable<Sensor>
    {
        public List<IObserver<Sensor>> observers;

        public SensorMonitor()
        {
            observers = new List<IObserver<Sensor>>();
        }

        public IDisposable Subscribe(IObserver<Sensor> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new Unsubscriber(observers, observer);
        }
    }
}
