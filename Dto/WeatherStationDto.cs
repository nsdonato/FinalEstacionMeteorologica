namespace WeatherStation.Api.Dto
{
    public class WeatherStationDto
    {
        //public CurrentConditions CurrentConditions { get; set; }
        //public EstadisticasDelTiempo EstadisticasDelTiempo { get; set; }
        //public SimpleForecast SimpleForecast { get; set; }

        public WeatherActualCondition WeatherActualCondition { get; set; }
        public WeatherStatistics WeatherStatistics { get; set; }
        public WeatherSimpleForecast WeatherSimpleForecast { get; set; }
    }
}
