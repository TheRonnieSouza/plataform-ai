using Microsoft.AspNetCore.Mvc;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace Action.Controllers
{
    [McpServerToolType]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [McpServerTool, Description("Return the weather to the client.")]
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [McpServerTool, Description("Return the time zone to the client, passing the parameter string country")]
        [HttpGet(Name = "GetTimeZone")]
        public  ActionResult<string> GetTimeZone(string country)
        {
            return Ok("New York");
        }
    }
}
