using System.ComponentModel.DataAnnotations;

namespace WebApplicationWeather.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        public virtual ICollection<WeatherDaily> Weathers { get; set; }
    }
}
