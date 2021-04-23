using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly WeatherAnalyzer _weatheranalyzer; 

        private readonly IDataReader _dataReader;

        public WeatherForecastController(IDataReader dataReader, WeatherAnalyzer weatheranalyzer)
        {

            _dataReader = dataReader;
            _weatheranalyzer = weatheranalyzer; 

        }

        [HttpGet]
        public async Task<ActionResult<List<TemperatureModel>>> GetAsync()
        {
            return Ok(await _dataReader.GetData());

        }
        [HttpGet("highesttemperature")]
        public async Task<ActionResult<float>> GetHighestTemperature()
        {
            return Ok(_weatheranalyzer.CheckMax(await _dataReader.GetData()));
            // return Ok( _weatheranalyzer.CheckMax(await _dataReader.GetData()).ToString() + "C, occured on " + _weatheranalyzer.GetWarmestDate(await _dataReader.GetData()).ToString());

        }

        [HttpGet("lowesttemperature")]
        public async Task<ActionResult<float>> GetLowestTemperature()
        {
            return Ok(_weatheranalyzer.CheckMin(await _dataReader.GetData()));
            //return Ok(_weatheranalyzer.CheckMin(await _dataReader.GetData()).ToString() + "C, occured on " + _weatheranalyzer.GetColdestDate(await _dataReader.GetData()).ToString());

        }

        [HttpGet("averagetemperature")]
        public async Task<ActionResult<float>> GetAverageTemperature()
        {
            return Ok(_weatheranalyzer.CheckAverage(await _dataReader.GetData()));

        }
    }
}
