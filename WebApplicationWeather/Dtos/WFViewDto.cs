using WebApplicationWeather.Models;

namespace WebApplicationWeather.Dtos
{
    public class WFViewDto
    {
        public WeatherForecast? WeatherForecast { get; set; }
        public List<WeatherDaily>? WeatherDailies { get; set; }
    }
}
