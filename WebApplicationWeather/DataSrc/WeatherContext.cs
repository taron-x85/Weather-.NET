using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebApplicationWeather.Models;

namespace WebApplicationWeather.DataSrc
{
    public class WeatherContext:DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options):base(options)
        {

        }

        public DbSet<WeatherDaily> WeatherDailies => Set<WeatherDaily>();
        public DbSet<WeatherHourly> WeatherHourlies => Set<WeatherHourly>();
        public DbSet<Summary> Summaries => Set<Summary>();
        public DbSet<Location> Locations => Set<Location>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WeatherHourly>().HasIndex(b => b.Time);
            modelBuilder.Entity<WeatherDaily>().HasIndex(b => b.Date);
            modelBuilder.Entity<Summary>().HasIndex(b => b.Title);

        }
    }
}
