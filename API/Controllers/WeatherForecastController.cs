using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController] //This particular class is of type API Controller
    [Route("[controller]")] //Route - how is the user going to get to the API controller from the client?
    public class WeatherForecastController : ControllerBase //Derived from ControllerBase
    {
        private static readonly string[] Summaries = new[] //string array of different summaries
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot"
        };

        private readonly ILogger<WeatherForecastController> _logger; //property for an eyelogger 

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet] //Controller end point
        public IEnumerable<WeatherForecast> Get() //Using a HTTP Get Request
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)] 
            })
            .ToArray(); //Returns the data in an array list of weather forecast 
        }
    }
}
