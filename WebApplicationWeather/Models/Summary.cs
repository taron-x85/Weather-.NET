using System.ComponentModel.DataAnnotations;

namespace WebApplicationWeather.Models
{
    public class Summary
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(50)]
        public string PicPath { get; set; }
        [Required]
        public bool IsNight { get; set; }
        public virtual ICollection<WeatherDaily> WeatherDailies { get; set; }
        public virtual ICollection<WeatherHourly> WeatherHourlies { get; set; }
    }
}
