using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherStation.Api.Pattern
{
    public class WeatherStatistics : IObserver<WeatherData> 
    {
        private IDisposable _unsubscriber;
        
        public IList<WeatherData> ListWeatherData = new List<WeatherData>(); //porque public ??, lo mismo abajo
        public IList<WeatherData> LastData = new List<WeatherData>(); //no me gusta que se creen en este momento, se podrian instanciar en el constructor
        public decimal MediumTemperature { get; private set; } //para las tres temperature, usaria un objeto que sea StatisticsTemperature, que tengan esas tres propiedades
        public decimal MinimumTemperature { get; private set; } //y el mediumTemperature se calcula en el get.. muy de goma lo que te estoy diciendo
        public decimal MaximumTemperature { get; private set; }
        public string Information { get; private set; }
        public string SensorName { get; }
        public bool Suscribed { get; set; }
       

        public WeatherStatistics()
        {
            SensorName = WEATHER_STATISTICS;
        }

        public virtual void Subscribe(IObservable<WeatherData> provider)
        {
            IsSuscribed = true;
            _unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            Suscribed = false;
            _unsubscriber.Dispose();
        }

        public virtual void OnCompleted()
        {
            //IsSuscribed = false; -> ya lo hace el unsuscribe
            Unsubscribe();
        }

        public virtual void OnError(Exception error)
        {
            Console.WriteLine("{0}: The provider cannot be read data.", SensorName);
        }

        public virtual void OnNext(WeatherData value)
        {
            ListWeatherData.Add(value);
            LastData = ListWeatherData.TakeLast(5).ToList();
            MinimumTemperature = ListWeatherData.Select(c => c.Temp).Min();
            MaximumTemperature = ListWeatherData.Select(c => c.Temp).Max();

            if (ListWeatherData.Count > 0)// si tiene una temperatura la promedio seria la misma, medio al dope toda la cuenta pero buen paja 
            {
                MediumTemperature = (MaximumTemperature + MinimumTemperature) / 2);
                Information = $"The average temperature is: {MediumTemperature}";
            }
            else
            {
                Information = "The average temperature will be available in minutes. ";
            }
        }
    }
}
