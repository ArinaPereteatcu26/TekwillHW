using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WeatherForecastController : ControllerBase
    {
        private static List<WeatherForecast> Summaries = new List<WeatherForecast>();


        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastRepository _weatherForecastRepository;




        public WeatherForecastController(ILogger<WeatherForecastController> logger, 
            IWeatherForecastRepository weatherForecastRepository)
        {
            _logger = logger;
            _weatherForecastRepository = weatherForecastRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> GetAll()
        {
            return _weatherForecastRepository.GetAll();
        }

        [HttpGet("{summary}", Name = "GetWeatherForecastByName")]
        public IActionResult GetByName(string summary)
        {

            try
            {
                var weather = _weatherForecastRepository.GetByName(summary);
                return Ok(weather);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost(Name = "CreateWeatherForecast")]
        public IActionResult Create(WeatherForecast weather)
        {
            try
            {
                _weatherForecastRepository.Create(weather);
                return Ok(weather);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateMultiple", Name = "CreateMultipleWeatherForecasts")]
        public IActionResult CreateMultiple(List<WeatherForecast> weatherForecasts)
        {
            var addForecasts = new List<WeatherForecast>();
            var existingForecasts = new List<string>();

            foreach (var weather in weatherForecasts)
            {
                if (Summaries.Any(x => x.Summary == weather.Summary))
                {
                    existingForecasts.Add(weather.Summary);
                }
                else
                {
                    Summaries.Add(weather);
                    addForecasts.Add(weather);
                }
            }
            if (existingForecasts.Count > 0)
            {
                return BadRequest($"Forecast exists");
            }
            return Ok(addForecasts);
        }

        [HttpDelete("{summary}", Name = "DeleteWeatherForecastByName")]
        public IActionResult DeleteByName(string summary)
        {
            try
            {
                _weatherForecastRepository.DeleteByName(summary);
                
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut(Name = "UpdateWeather")]
        public IActionResult Update(WeatherForecast weatherForecast)
        {
            try
            {
                _weatherForecastRepository.Update(weatherForecast);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
