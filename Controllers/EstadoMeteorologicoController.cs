using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstacionMeteorologica.Api.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EstacionMeteorologica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoMeteorologicoController : ControllerBase
    {
        private const string WEATHER_ACTUA_CONDITION = "WeatherActualCondition";
        private const string WEATHER_SIMPLE_FORECAST = "WeatherSimpleForecast";
        private const string WEATHER_STATISTICS = "WeatherStatistics";
        static int cont = 0;

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetEstadoMeteorologico()
        {


            //return new string[] { "value1", "value2" };
            //var json = new string[] { "value1", "value2" };

            //var monitorProvedir = new SensorMonitor();

            //var condicionesActuales = new SensorReporter("GetCondicionesActuales");
            //var estadisticasDelTiempo = new SensorReporter("GetEstadisticasDelTiempo");
            //var pronosticoSimple = new SensorReporter("GetPronosticoSimple");
            //condicionesActuales.Subscribe(monitorProvedir);
            //estadisticasDelTiempo.Subscribe(monitorProvedir);
            //pronosticoSimple.Subscribe(monitorProvedir);

            //// Acá o en un service.. donde sea, haríamos la llamada a la api del clima.

            //// Create an array of sample data to mimic a temperature device.
            //Nullable<Decimal>[] temps = { 1m, 1m, 5m, 7m, 7m, 13m, 20m, 20, 28m, 30m };
            //Nullable<Decimal>[] hums = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            //Nullable<Double>[] pres = { 100.10d, 210.20d, 14.7d, 14.9d, 14.9d, 250d, 560d, 810d, 900d, 1.080d };

            //// Store the previous temperature, so notification is only sent after at least .1 change.
            //Nullable<Decimal> previousTemp = null;
            //bool start = true;

            ////foreach (var temp in temps)
            //for (int i = 0; i < temps.Length; i++)
            //{
            //    //System.Threading.Thread.Sleep(2500);
            //    if (temps[i].HasValue)
            //    {
            //        if (start || (Math.Abs(temps[i].Value - previousTemp.Value) >= 0.1m))
            //        {
            //            BaseSensor sensorData = new BaseSensor(temps[i].Value, hums[i].Value, pres[i].Value, DateTime.Now);

            //            foreach (var observer in monitorProvedir.observers)
            //            {
            //                //Console.WriteLine("Observer: " + observer.ToString());
            //                //Console.WriteLine("Temp: " + tempData.Degrees + " .Fecha: " + tempData.Date);
            //                observer.OnNext(sensorData);
            //            }

            //            previousTemp = temps[i];
            //            if (start) start = false;
            //        }
            //    }
            //    else
            //    {
            //        foreach (var observer in monitorProvedir.observers.ToArray())
            //            if (observer != null) observer.OnCompleted();

            //        monitorProvedir.observers.Clear();
            //        break;
            //    }
            //}

            //var result = new EstacionMeteorologicaDto()
            //{
            //    CondicionesActuales = new CondicionesActuales(20, 30, 50, DateTime.Now),
            //    PronosticoSimple = new PronosticoSimple(60,70,80,DateTime.Now.AddDays(1))
            //};

            WeatherSubscriber subscriber = new WeatherSubscriber();

            WeatherActualCondition actualCondition = new WeatherActualCondition("WeatherActualCondition");
            WeatherStatistics statistics = new WeatherStatistics("WeatherStatistics");
            WeatherSimpleForecast simpleForecast = new WeatherSimpleForecast("WeatherSimpleForecast");

            actualCondition.Subscribe(subscriber);
            statistics.Subscribe(subscriber);
            simpleForecast.Subscribe(subscriber);

            decimal[] temps = { 1m, 1m, 5m, 7m, 7m, 13m, 20m, 20, 28m, 30m };
            decimal[] hums = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            double[] pres = { 100.10d, 210.20d, 14.7d, 14.9d, 14.9d, 250d, 560d, 810d, 900d, 1.080d };

            if (cont == 10)
                cont = 0;

            subscriber.SetMeasurements(new WeatherData(temps[cont], hums[cont], pres[cont], DateTime.Now));
           
            //subscriber.SetMeasurements(null);

            //Console.Read();

            var result = new EstacionMeteorologicaDto();

            foreach (var item in subscriber.observers)
            {
                switch (item.GetType().Name)
                {
                    case WEATHER_ACTUA_CONDITION:

                        result.CondicionesActuales = new CondicionesActuales(
                                                        ((WeatherActualCondition)item).last.Temp,
                                                        ((WeatherActualCondition)item).last.Hum,
                                                        ((WeatherActualCondition)item).last.Pres,
                                                        DateTime.Now);
                        break;
                    case WEATHER_SIMPLE_FORECAST:

                        result.PronosticoSimple = new PronosticoSimple(
                                                        ((WeatherSimpleForecast)item).last.Temp,
                                                        ((WeatherSimpleForecast)item).last.Hum,
                                                        ((WeatherSimpleForecast)item).last.Pres,
                                                        DateTime.Now);

                        break;
                        //case WEATHER_STATISTICS:

                        //    result.CondicionesActuales = new CondicionesActuales(
                        //                                    ((WeatherActualCondition)item).last.Temp,
                        //                                    ((WeatherActualCondition)item).last.hum,
                        //                                    ((WeatherActualCondition)item).last.pres,
                        //                                    DateTime.Now);
                        //    break;
                }
            }

            // http://api.openweathermap.org/data/2.5/weather?lat=-34.605019&lon=-58.376068&units=metric&APPID=5134ad0266da5e981b25f1d569d4c8f6

            cont++;
            return Ok(result);
        }

        //// GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> GetCondicionesActuales()
        //{
        //    //return new string[] { "value1", "value2" };
        //    var json = new string[] { "value1", "value2" };

        //    return Ok(json);
        //}

        //[HttpGet]
        //public ActionResult<IEnumerable<string>> GetEstadisticasDelTiempo()
        //{
        //    return new string[] { "value1", "value2" };

        //    //return Ok(provider);
        //}


        //[HttpGet]
        //public ActionResult<IEnumerable<string>> GetPronosticoSimple()
        //{
        //    return new string[] { "value1", "value2" };

        //    //return Ok(provider);
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
           

            Redirect("/GetCondicionesActuales");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
