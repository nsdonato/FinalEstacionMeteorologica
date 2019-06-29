using System;
using WeatherStation.Api.ViewModels;
using WeatherStation.Api.Helper;
using Microsoft.AspNetCore.Mvc;
using WeatherStation.Api.Pattern;

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
        public IActionResult GetWeatherStation()
        {
            actualCondition.Subscribe(subscriber);
            statistics.Subscribe(subscriber);
            simpleForecast.Subscribe(subscriber);

            subscriber.SetMeasurements(new WeatherData(WeatherHelper.GetTemperature(), WeatherHelper.GetHumidity(), WeatherHelper.GetPressure(), DateTime.Now));

            this.Result.WeatherActualCondition = actualCondition;
            this.Result.WeatherSimpleForecast = simpleForecast;
            this.Result.WeatherStatistics = statistics;

            return Ok(this.Result);
        }

        [HttpDelete]
        public IActionResult DeleteSuscriber(string weatherType)
        {
            subscriber.observers.ForEach(m => {
                if (m.GetType().Name == weatherType)
                    m.OnCompleted();
                return;
            });

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
