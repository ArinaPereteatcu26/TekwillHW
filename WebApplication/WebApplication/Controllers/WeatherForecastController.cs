using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<WeatherForecast> Summaries = new List<WeatherForecast>
        {
            new WeatherForecast { Date = DateTime.Now.AddDays(1), TemperatureC = 25, Summary = "Hot"},
            new WeatherForecast { Date = DateTime.Now.AddDays(2), TemperatureC = 15, Summary = "Cold"},
            new WeatherForecast { Date = DateTime.Now.AddDays(3), TemperatureC = 20, Summary = "Warm"},
            new WeatherForecast { Date = DateTime.Now.AddDays(4), TemperatureC = 30, Summary = "Very Hot"},
            new WeatherForecast { Date = DateTime.Now.AddDays(5), TemperatureC = 10, Summary = "Very Cold"}
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> GetAll()
        {
            return Summaries;
        }

        [HttpGet("{summary}", Name = "GetWeatherForecastByName")]
        public IActionResult GetByName(string summary)
        {
            var weather = Summaries.FirstOrDefault(x => x.Summary == summary);
            if (weather == null)
            {
                return NotFound();
            }
            return Ok(weather);
        }

        [HttpPost(Name = "CreateWeatherForecast")]
        public IActionResult Create(WeatherForecast weather)
        {
            var weatherFromList = Summaries.FirstOrDefault(x => x.Summary == weather.Summary);
            if (weatherFromList == null)
            {
                Summaries.Add(weather);
                return CreatedAtRoute("GetWeatherForecastByName", new { weather.Summary }, weather.Summary);
            }
            return BadRequest("Already Exists");
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
            var weather = Summaries.FirstOrDefault(x => x.Summary == summary);
            if (weather == null)
            {
                return NotFound();
            }
            Summaries.Remove(weather);

            return Ok();
        }

        [HttpPut("{summary}", Name = "UpdateWeatherByName")]
        public IActionResult UpdateWeather(string summary, WeatherForecast weatherForecast)
        {
            var index = Summaries.FindIndex(x => x.Summary == summary);
            if (index == -1)
            {
                return NotFound();
            }
            Summaries[index].Date = weatherForecast.Date;
            Summaries[index].TemperatureC = weatherForecast.TemperatureC;
            

            return Ok();
        }
    }
}
