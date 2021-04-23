using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApi
{
    public class SMHIDataToTemperatureReader : IDataReader
    {
        private int _place;
        private List<TemperatureModel> data;

        public SMHIDataToTemperatureReader(int place)
        {
            _place = place;
        }

        public async Task<List<TemperatureModel>> GetData()
        {
            var url = $"https://opendata-download-metobs.smhi.se/api/version/latest/parameter/1/station/" + _place.ToString() + "/period/latest-months/data.json";
            var httpClient = new HttpClient();
           
            var rootResponse = await httpClient.GetAsync(url);
          
            //if (rootResponse.StatusCode == HttpStatusCode.NotFound)
            //{
            //    throw new System.Exception("Url not found");
            //}

            var result = await rootResponse.Content.ReadFromJsonAsync<SMHIWeatherForecast>();
            var SMHIconverter = new ConvertSMHIData();
            data = SMHIconverter.ToTemperatureModel(result);

            return data;
        }

    }
}
