
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AnalyzeWeather
{
    public class SMHIDataToTemperatureReader : IDataReader
    {
        private int _place;
        private string _info; 

        public SMHIDataToTemperatureReader(int place)//, DateTime startDate, DateTime endDate )
        {
            _place = place;
        }

        public async Task<List<TemperatureModel>> GetData()
        {
          
            HttpClient client = new HttpClient();
            var url = $"https://opendata-download-metobs.smhi.se/api/version/latest/parameter/1/station/" + _place.ToString() + "/period/latest-months/data.json";
            var httpClient = new HttpClient();
            var rootResponse = await httpClient.GetFromJsonAsync<WeatherForecast>(url);
           
            var SMHIconverter = new ConvertSMHIData();
            _info = rootResponse.period.ToString();

            return SMHIconverter.ToTemperatureModel(rootResponse);
        }

  

    }
}
