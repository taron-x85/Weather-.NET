using WebApplicationWeather.Models;

namespace WebApplicationWeather.Dtos
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int Humidity { get; set; }
        public int Wind { get; set; }
        public string Location { get; set; }
        public string DayOfWeek { get; set; }
        public Summary Summary { get; set; }
    }
}