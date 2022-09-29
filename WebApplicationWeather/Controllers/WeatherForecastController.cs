using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationWeather.Dtos;
using WebApplicationWeather.Models;
using WebApplicationWeather.Services;

namespace WebApplicationWeather.Controllers
{
    [ApiController]
    [EnableCors("ReactPolicy")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IWeatherService weatherService, ILogger<WeatherForecastController> logger)
        {
            _weatherService = weatherService;
            _logger = logger;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("CurrentForecast")]
        public async ValueTask<IActionResult> Get()
        {
            List<Summary> sums = await _weatherService.GetSummaries();
            Location location = await _weatherService.GetLocationById(1);
            WeatherForecast wFCorrent = new();

            wFCorrent.Date = DateTime.Now;
            wFCorrent.TemperatureC = Random.Shared.Next(-55, 55);
            wFCorrent.Summary = sums[Random.Shared.Next(sums.Count)];
            wFCorrent.Location = location.City;
            wFCorrent.Humidity = Random.Shared.Next(1, 99);
            wFCorrent.Wind = Random.Shared.Next(1, 99);
            wFCorrent.DayOfWeek = DateTime.Now.DayOfWeek.ToString();
                var weatherDailies = await _weatherService.GetDailyAsync(DateTime.Now.Date);
            if (weatherDailies is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new WFViewDto
                {
                    WeatherDailies = weatherDailies,
                    WeatherForecast = wFCorrent,
                });
            }
            _logger.LogInformation("***  GetWeatherForecastCurrent  ***");
        }

        [HttpPost]
        [Route("AddDailyForcast")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async ValueTask<ActionResult> AddDailyForcast([FromBody] WeatherDailyDto weatherDaily)
        {
            if(weatherDaily == null)
            {
                return BadRequest();
            }

            return Ok(await _weatherService.AddDailyAsync(weatherDaily));
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutDaily(int id, WeatherDailyDto dailyDto)
        {
            if (dailyDto is null)
            {
                return BadRequest();
            }

            WeatherDaily? cat = await _weatherService.UpdateAsync(id,dailyDto);
            if (cat is null)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            WeatherDaily? category = await _weatherService.RemoveAsync(id);
            if (category is null)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("MaxTemp/{day}")]
        public async Task<ActionResult> GetCategories(DateTime day)
        {
            WeatherDaily? dailyMax = await _weatherService.FindMaxTempAsync(day);
            if (dailyMax is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dailyMax);
            }
        }

    }
}