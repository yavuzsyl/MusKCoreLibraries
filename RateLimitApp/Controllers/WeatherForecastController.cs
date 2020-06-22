using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace RateLimitApp.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rng = new Random();
            return await Task.Run(() => Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray()));
            
        }

        [HttpGet]
        public async Task<IActionResult> GetV2()
        {
            var rng = new Random();
            return await Task.Run(() => Ok(Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray()));

        }

        [HttpPut]
        public async Task<IActionResult> Putit()
        {
            string asd = "24";
            int fsa = 0;
            await Task.Run(() => fsa = int.Parse(asd));
            return Ok();
        }

        //[HttpGet]route içinde belirtmeden parametre gönderilmek isteniyorsa parametre isimleri request urlinde querystring olarak yazılır , eğer veriler routedan alınmak isteniyorsa route gelecek parametrelere göre düzenlenir [HttpGet("{name}")] /controller/action/isim gibi
        [HttpGet("{werwe}/{asd}")]
        public IActionResult Getit(int werwe,string asd)
        {
            return Ok(werwe);
        }
    }
}
