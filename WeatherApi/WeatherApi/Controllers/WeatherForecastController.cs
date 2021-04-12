using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
// private readonly IWeatherSercvice _weatherservice; // interface med getwarmest som tar in list of  temperature model och 

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IDataReader _dataReader; 
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDataReader dataReader)
        {
            _dataReader = dataReader;
            _logger = logger;

        }

        [HttpGet]
        public ActionResult<string> Get()
        {

            // get data from Idatareader (kommer in i konstruktorn) (temperature model=
            return _dataReader.GetDataAsJSON();
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
