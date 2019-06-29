using System;
using WeatherStation.Api.Dto;
using WeatherStation.Api.Helper;
using Microsoft.AspNetCore.Mvc;

namespace WeatherStation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherStationController : ControllerBase
    {
        private const string WEATHER_ACTUAL_CONDITION = "WeatherActualCondition";
        private const string WEATHER_SIMPLE_FORECAST = "WeatherSimpleForecast";
        private const string WEATHER_STATISTICS = "WeatherStatistics";

        private readonly WeatherStationDto Result = new WeatherStationDto();
        private readonly WeatherProvider subscriber = new WeatherProvider();

        private readonly WeatherActualCondition actualCondition = new WeatherActualCondition(WEATHER_ACTUAL_CONDITION);
        private static readonly WeatherStatistics statistics = new WeatherStatistics(WEATHER_STATISTICS);
        private readonly WeatherSimpleForecast simpleForecast = new WeatherSimpleForecast(WEATHER_SIMPLE_FORECAST);

        [HttpGet]
        public IActionResult GetWeatherStationDto()
        {
            actualCondition.Subscribe(subscriber);
            statistics.Subscribe(subscriber);
            simpleForecast.Subscribe(subscriber);

            subscriber.SetMeasurements(new WeatherData(
                        WeatherHelper.getTemperature(),
                        WeatherHelper.getHumidity(),
                        WeatherHelper.getPressure(),
                        DateTime.Now));

            this.Result.WeatherActualCondition = actualCondition;
            this.Result.WeatherSimpleForecast = simpleForecast;
            this.Result.WeatherStatistics = statistics;

            //getResults();

            return Ok(this.Result);
        }

        //private void getResults()
        //{
        //    foreach (var item in subscriber.observers)
        //    {
        //        switch (item.GetType().Name)
        //        {
        //            case WEATHER_ACTUAL_CONDITION:

        //                this.Result.WeatherActualCondition = new WeatherActualCondition()
        //                    //new CurrentConditions(
        //                    //                            ((WeatherActualCondition)item).last.Temp,
        //                    //                            ((WeatherActualCondition)item).last.Hum,
        //                    //                            ((WeatherActualCondition)item).last.Pres,
        //                    //                            DateTime.Now);
        //                break;
        //            case WEATHER_SIMPLE_FORECAST:

        //                this.Result.WeatherSimpleForecast = 
        //                    //new SimpleForecast(
        //                    //                            ((WeatherSimpleForecast)item).last.Temp,
        //                    //                            ((WeatherSimpleForecast)item).last.Hum,
        //                    //                            ((WeatherSimpleForecast)item).last.Pres,
        //                    //                            DateTime.Now);

        //                break;
        //                //case WEATHER_STATISTICS:

        //                //    result.CondicionesActuales = new CondicionesActuales(
        //                //                                    ((WeatherActualCondition)item).last.Temp,
        //                //                                    ((WeatherActualCondition)item).last.hum,
        //                //                                    ((WeatherActualCondition)item).last.pres,
        //                //                                    DateTime.Now);
        //                //    break;
        //        }
        //    }
        //}

        [HttpDelete]
        public IActionResult DeleteSuscriber(string weatherType)
        {
            foreach (var item in subscriber.observers)
            {
                if (item.GetType().Name == weatherType)
                {
                    item.OnCompleted();
                }
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult PostSuscriber(string weatherType)
        {
            switch (weatherType)
            {
                case WEATHER_ACTUAL_CONDITION:
                    subscriber.Subscribe(actualCondition);
                    break;
                case WEATHER_SIMPLE_FORECAST:
                    subscriber.Subscribe(simpleForecast);
                    break;
                default:
                    subscriber.Subscribe(statistics);
                    break;
            }

            return Ok();
        }
    }
}
