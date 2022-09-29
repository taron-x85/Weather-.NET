using System.ComponentModel.DataAnnotations;

namespace WebApplicationWeather.Models
{
    public class WeatherHourly
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }

        [Range(typeof(float), "-60.0f", "60.0f")]
        public float TemperatureC { get; set; }

        public int? WeatherDailyId { get; set; }
        public virtual WeatherDaily? WeatherDaily { get; set; }
        public int LocationId { get; set; }
        public virtual Location? Location { get; set; }
        public int SummaryId { get; set; }
        public virtual Summary? Summary { get; set; }
    }
}
