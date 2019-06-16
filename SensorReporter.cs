using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionMeteorologica
{
    public class SensorReporter : IObserver<Sensor>
    {
        private IDisposable unsubscriber;
        private bool first = true;
        private Sensor last;

        public virtual void Subscribe(IObservable<Sensor> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine("La temperatura adicional no será transimitada.");
        }

        public virtual void OnError(Exception error)
        {
            // Do nothing.
        }

        public virtual void OnNext(Sensor value)
        {
            Console.WriteLine("La temperatura es {0}°C. Fecha: {1:g}", value.temp, value.Date);
            if (first)
            {
                last = value;
                first = false;
            }
            else
            {
                Console.WriteLine("Cambio de temperatura: {0}°C. Fecha: {1:g}",
                    value.temp - last.temp,
                    value.Date.ToUniversalTime() - last.Date.ToUniversalTime());
            }
        }


    }
}
