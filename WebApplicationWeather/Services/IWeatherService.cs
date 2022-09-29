using WebApplicationWeather.DataSrc;
using WebApplicationWeather.Dtos;
using WebApplicationWeather.Models;

namespace WebApplicationWeather.Services
{
    public interface IWeatherService
    {
        Task<List<WeatherDaily>> GetDailyAsync(DateTime date);
        Task<WeatherDaily?> FindMaxTempAsync(DateTime day);
        ValueTask<List<Summary>> GetSummaries();
        ValueTask<Location> GetLocationById(int id);
        ValueTask<int> AddDailyAsync(WeatherDailyDto wth);
        Task<WeatherDaily?> RemoveAsync(int id);
        Task<WeatherDaily?> UpdateAsync(int id, WeatherDailyDto wth);
    }
}
