using Microsoft.AspNetCore.Mvc;
using NET_FiveMinutes_010_AbpModuleDev.Services;

namespace NET_FiveMinutes_010_AbpModuleDev.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ReadAppSettingsService _readAppSettingsService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ReadAppSettingsService readAppSettingsService)
        {
            _logger = logger;
            _readAppSettingsService = readAppSettingsService;
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

        [HttpGet(Name = "GetFileConten")]
        public ActionResult<string> GetFileContent()
        {
            return _readAppSettingsService.ReadAppSetttingsJson();
        }
    }
}