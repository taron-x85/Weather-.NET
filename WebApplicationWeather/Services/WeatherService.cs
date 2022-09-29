using Microsoft.EntityFrameworkCore;
using WebApplicationWeather.DataSrc;
using WebApplicationWeather.Dtos;
using WebApplicationWeather.Models;

namespace WebApplicationWeather.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherContext _wthContext;

        public WeatherService(WeatherContext wthContext)
        {
            _wthContext = wthContext;
        }

        public async ValueTask<int> AddDailyAsync(WeatherDailyDto wth)
        {
            _wthContext.WeatherDailies.Add(new WeatherDaily
            {
                Date = wth.Date,
                TemperatureMaxC = wth.TemperatureMaxC,
                TemperatureMinC = wth.TemperatureMinC,
                LocationId = wth.LocationId,
                SummaryId = wth.SummaryId,
                IsActive = wth.IsActive
            });
            return await _wthContext.SaveChangesAsync();
        }

        public async Task<WeatherDaily?> FindMaxTempAsync(DateTime day)
        {
            List<WeatherDaily> weathersMidTemp = await _wthContext.WeatherDailies.Where(x => x.Date >= day.Date && x.Date <= day.AddDays(7)).ToListAsync();
            if (weathersMidTemp is null) return null;
            float maxTemp = weathersMidTemp.Max(c => (c.TemperatureMinC + c.TemperatureMaxC) / 2);
            return weathersMidTemp.Where(c => ((c.TemperatureMinC + c.TemperatureMaxC) / 2) == maxTemp).First();
        }

        public async Task<List<WeatherDaily>> GetDailyAsync(DateTime day)=> 
            await _wthContext.WeatherDailies.Where(x => x.Date >= day.Date && x.Date<=day.AddDays(7)).ToListAsync();

        public async ValueTask<Location> GetLocationById(int id) => await _wthContext.Locations.FindAsync(id);

        public async ValueTask<List<Summary>> GetSummaries() => await _wthContext.Summaries.ToListAsync();

        public Task<IEnumerable<WeatherDaily>> GetTreeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<WeatherDaily?> RemoveAsync(int id)
        {
            WeatherDaily? _weatherDaily = await _wthContext.WeatherDailies.FindAsync(id);
            if (_weatherDaily is null) return null;
            _wthContext.WeatherDailies.Remove(_weatherDaily);
            await _wthContext.SaveChangesAsync();
            return _weatherDaily;
        }

        public async Task<WeatherDaily?> UpdateAsync(int id, WeatherDailyDto dailyDto)
        {
            WeatherDaily? _weatherDaily = await _wthContext.WeatherDailies.FindAsync(id);

            if (_weatherDaily is null) return null;
            _weatherDaily.Date = dailyDto.Date;
            _weatherDaily.TemperatureMaxC = dailyDto.TemperatureMaxC;
            _weatherDaily.TemperatureMinC = dailyDto.TemperatureMinC;
            _weatherDaily.LocationId = dailyDto.LocationId;
            _weatherDaily.SummaryId = dailyDto.SummaryId;
            _weatherDaily.IsActive = dailyDto.IsActive;

            _wthContext.Entry(_weatherDaily).State = EntityState.Modified;
            await _wthContext.SaveChangesAsync();
            return _weatherDaily;

        }
    }
}
