using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using WebApplicationWeather.Models;

namespace WebApplicationWeather.Dtos
{
    public class WeatherDailyDto
    {
        public DateTime Date { get; set; }
        public float TemperatureMaxC { get; set; }     
        public float TemperatureMinC { get; set; }
        public int LocationId { get; set; }
        public int SummaryId { get; set; }     
        public bool IsActive { get; set; }

    }
}
