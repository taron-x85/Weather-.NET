using Microsoft.EntityFrameworkCore;
using WebApplicationWeather.DataSrc;
using WebApplicationWeather.Models;

namespace WebApplicationWeather.Services
{
    public class DataSeeder : IDataSeeder
    {
        private readonly WeatherContext _weatherContext;

        public DataSeeder(WeatherContext weatherContext)
        {
            _weatherContext = weatherContext;
        }

        public async ValueTask Seed()
        {
            if (!await _weatherContext.Summaries.AnyAsync())
            {
                var summs = new List<Summary>()
                {
                    new Summary()
                    {
                        Title="Clear Sky",
                        PicPath="01d",
                        IsNight=false
                    },
                    new Summary()
                    {
                        Title="Clear Sky",
                        PicPath="01n",
                        IsNight=true
                    },
                    new Summary()
                    {
                        Title="Few Clouds",
                        PicPath="02d",
                        IsNight=false
                    },
                    new Summary()
                    {
                        Title="Few Clouds",
                        PicPath="02n",
                        IsNight=true
                    },
                    new Summary()
                    {
                        Title="Scattered Clouds",
                        PicPath="03d",
                        IsNight=false
                    },
                    new Summary()
                    {
                        Title="Scattered Clouds",
                        PicPath="03n",
                        IsNight=true
                    },

                    // ----------------------------

                     new Summary()
                    {
                        Title="Broken Clouds",
                        PicPath="04d",
                        IsNight=false
                    },
                    new Summary()
                    {
                        Title="Broken Clouds",
                        PicPath="04n",
                        IsNight=true
                    },
                    new Summary()
                    {
                        Title="Shower Rain",
                        PicPath="09d",
                        IsNight=false
                    },
                    new Summary()
                    {
                        Title="Shower Rain",
                        PicPath="09n",
                        IsNight=true
                    },
                    new Summary()
                    {
                        Title="Rain",
                        PicPath="10d",
                        IsNight=false
                    },
                    new Summary()
                    {
                        Title="Rain",
                        PicPath="10n",
                        IsNight=true
                    },
                     // ----------------------------

                     new Summary()
                    {
                        Title="Thunderstorm",
                        PicPath="11d",
                        IsNight=false
                    },
                    new Summary()
                    {
                        Title="Thunderstorm",
                        PicPath="11n",
                        IsNight=true
                    },
                    new Summary()
                    {
                        Title="Snow",
                        PicPath="13d",
                        IsNight=false
                    },
                    new Summary()
                    {
                        Title="Snow",
                        PicPath="13n",
                        IsNight=true
                    },
                    new Summary()
                    {
                        Title="Mist",
                        PicPath="50d",
                        IsNight=false
                    },
                    new Summary()
                    {
                        Title="Mist",
                        PicPath="50n",
                        IsNight=true
                    }
                };

                _weatherContext.Summaries.AddRange(summs);  
            }

            if (!await _weatherContext.Locations.AnyAsync())
            {
                var locats = new List<Location>()
                    {
                    new Location()
                    {
                        City="Yerevan"
                    },
                    new Location()
                    {
                        City="Moscow"
                    }
                    };
                _weatherContext.Locations.AddRange(locats);
            }

            await _weatherContext.SaveChangesAsync();
        }
    }
}
