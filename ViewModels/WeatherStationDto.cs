using WeatherStation.Api.Pattern;

namespace WeatherStation.Api.ViewModels
{
    public class WeatherStationDto
    {
        public WeatherActualCondition WeatherActualCondition { get; set; }
        public WeatherStatistics WeatherStatistics { get; set; }
        public WeatherSimpleForecast WeatherSimpleForecast { get; set; }
    }
}
