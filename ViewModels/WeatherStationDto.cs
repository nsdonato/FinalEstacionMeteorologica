using WeatherStation.Api.Pattern;

namespace WeatherStation.Api.ViewModels
{
    public class WeatherStationDto
    {
        public WeatherCurrentCondition WeatherCurrentCondition { get; set; }
        public WeatherStatistics WeatherStatistics { get; set; }
        public WeatherSimpleForecast WeatherSimpleForecast { get; set; }
    }
}
