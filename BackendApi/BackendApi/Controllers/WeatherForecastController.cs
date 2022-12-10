using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string key;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;

            _configuration = configuration;

            // sample:
            key = _configuration.GetValue<string>("Child_Key");
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [Route("~/test")]
        [HttpGet]
        public IEnumerable<WeatherForecast> Test()
        {
            var range = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();

            range.Add(new WeatherForecast
            {
                Date = DateTime.Now.AddDays(5),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = "Adam be 2"
            });

            range.Add(new WeatherForecast
            {
                Date = DateTime.Now.AddDays(5),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = key
            });

            return range;


        }
    }
}