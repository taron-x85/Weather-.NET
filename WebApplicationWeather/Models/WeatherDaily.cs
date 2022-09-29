using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationWeather.Models
{
    public class WeatherDaily
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Range(typeof(float),"-60.0f", "60.0f")]
        public float TemperatureMaxC { get; set; }
        [Range(typeof(float), "-60.0f", "60.0f")]
        public float TemperatureMinC { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public virtual ICollection<WeatherHourly> WeatherHourlies { get; set; }
        public int LocationId { get; set; }
        public virtual Location? Location { get; set; }
        public int SummaryId { get; set; }
        public virtual Summary? Summary { get; set; }
    }
}