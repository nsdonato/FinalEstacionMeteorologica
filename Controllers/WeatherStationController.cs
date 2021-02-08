using Microsoft.AspNetCore.Mvc;
using System;
using WeatherStation.Api.Helper;
using WeatherStation.Api.Pattern;
using WeatherStation.Api.ViewModels;

namespace WeatherStation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherStationController : ControllerBase
    {
        public const string WEATHER_ACTUAL_CONDITION = "WeatherCurrentCondition";
        public const string WEATHER_SIMPLE_FORECAST = "WeatherSimpleForecast";
        public const string WEATHER_STATISTICS = "WeatherStatistics";

        private static readonly WeatherStationDto _result = new WeatherStationDto();
        private static readonly WeatherCurrentCondition _actualCondition = new WeatherCurrentCondition(WEATHER_ACTUAL_CONDITION);
        private static readonly WeatherSimpleForecast simpleForecast = new WeatherSimpleForecast(WEATHER_SIMPLE_FORECAST);
        private static readonly WeatherStatistics statistics = new WeatherStatistics(WEATHER_STATISTICS);
        private static WeatherProvider _provider;

        public WeatherStationController()
        {
            if (_provider == null)
            {
                _provider = new WeatherProvider();
                _actualCondition.Subscribe(_provider);
                statistics.Subscribe(_provider);
                simpleForecast.Subscribe(_provider);
            }
        }

        [HttpGet]
        public IActionResult GetWeatherStation()
        {
            _provider.SetMeasurements(new WeatherData(WeatherHelper.GetTemperature(), WeatherHelper.GetHumidity(), WeatherHelper.GetPressure(), DateTime.Now));

            _result.WeatherCurrentCondition = _actualCondition;
            _result.WeatherSimpleForecast = simpleForecast;
            _result.WeatherStatistics = statistics;

            return Ok(Result);
        }

        [HttpDelete]
        [Route("{weatherType}")]
        public IActionResult DeleteSuscriber(string weatherType)
        {
            foreach (var item in _provider.Observers)
            {
                if (item.GetType().Name.Equals(weatherType))//tal vez le meteria un toUpper
                {
                    item.OnCompleted();
                    break;
                }
            }
            return Ok();
        }

        [HttpPost]
        [Route("{weatherType}")]
        public IActionResult PostSuscriber(string weatherType)
        {
            switch (weatherType)
            {
                case WEATHER_ACTUAL_CONDITION:
                    actualCondition.Subscribe(_provider);
                    break;
                case WEATHER_SIMPLE_FORECAST:
                    simpleForecast.Subscribe(_provider);
                    break;
                default:
                    statistics.Subscribe(_provider);
                    break;
            }

            return Created("api/[controller]/weatherstation/weatherType", _result);
        }


    }
}
