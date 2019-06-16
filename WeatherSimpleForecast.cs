using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionMeteorologica.Api
{
    public class WeatherSimpleForecast : IObserver<WeatherData>
    {
        private IDisposable unsubscriber;
        private bool first = true;
        public WeatherData last { get; private set; }
        public string sensorName { get; private set; }

        public WeatherSimpleForecast(string name)
        {
            this.sensorName = name;
        }

        public virtual void Subscribe(IObservable<WeatherData> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public virtual void OnCompleted()
        {
            //Console.WriteLine("La temperatura adicional no será transimitada.");
            Console.WriteLine("The Provider has completed transmitting data to {0}.", this.sensorName);
            this.Unsubscribe();
        }

        public virtual void OnError(Exception error)
        {
            Console.WriteLine("{0}: The provider cannot be read data.", this.sensorName);
        }

        public virtual void OnNext(WeatherData value)
        {
            //Console.WriteLine("{3}: The current Weather is Temperature: {0}, Pressure {1}, Humidty {2}", value.Temperature, value.Presssure, value.Humidity, this.Name);

            Console.WriteLine("La temperatura es {0}°C. Fecha: {1:g}", value.Temp, value.Date);
            if (first)
            {
                last = value;
                first = false;
            }
            else
            {
                Console.WriteLine("Cambio de temperatura: {0}°C. Fecha: {1:g}",
                    value.Temp - last.Temp,
                    value.Date.ToUniversalTime() - last.Date.ToUniversalTime());
            }
        }


    }
}
