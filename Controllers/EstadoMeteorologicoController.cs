using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EstacionMeteorologica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoMeteorologicoController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetCondicionesActuales()
        {
            //return new string[] { "value1", "value2" };
            var json = new string[] { "value1", "value2" };

            return Ok(json);
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetEstadisticasDelTiempo()
        {
            return new string[] { "value1", "value2" };

            //return Ok(provider);
        }


        [HttpGet]
        public ActionResult<IEnumerable<string>> GetPronosticoSimple()
        {
            return new string[] { "value1", "value2" };

            //return Ok(provider);
        }

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
            var monitorProvedir = new SensorMonitor();

            var tempReporter1 = new SensorReporter();
            tempReporter1.Subscribe(monitorProvedir);

            // Create an array of sample data to mimic a temperature device.
            Nullable<Decimal>[] temps = { 1m, 1m, 5m, 7m, 7m, 13m, 20m, 20, 28m, 30m, null };
            Nullable<Decimal>[] hums = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, null };
            Nullable<Double>[] pres = { 100.10d, 210.20d, 14.7d, 14.9d, 14.9d, 250d, 560d, 810d, 900d, 1.080d, null };

            // Store the previous temperature, so notification is only sent after at least .1 change.
            Nullable<Decimal> previousTemp = null;
            bool start = true;

            //foreach (var temp in temps)
            for (int i = 0; i <= temps.Length; i++)
            {
                System.Threading.Thread.Sleep(2500);
                if (temps[0].HasValue)
                {
                    if (start || (Math.Abs(temps[i].Value - previousTemp.Value) >= 0.1m))
                    {
                        Sensor sensorData = new Sensor(temps[i].Value, hums[i].Value, pres[i].Value, DateTime.Now);

                        foreach (var observer in monitorProvedir.observers)
                        {
                            //Console.WriteLine("Observer: " + observer.ToString());
                            //Console.WriteLine("Temp: " + tempData.Degrees + " .Fecha: " + tempData.Date);
                            observer.OnNext(sensorData);
                        }


                        previousTemp = temps[i];
                        if (start) start = false;
                    }
                }
                else
                {
                    foreach (var observer in monitorProvedir.observers.ToArray())
                        if (observer != null) observer.OnCompleted();

                    monitorProvedir.observers.Clear();
                    break;
                }
            }

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
