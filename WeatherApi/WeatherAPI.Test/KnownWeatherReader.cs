using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;

using Newtonsoft.Json;

namespace WeatherApi.Test
{
    public class KnownWeatherReader : IDataReader
    {
        public KnownWeatherReader()
        {

        }

        public async Task<List<TemperatureModel>> GetData()
        {
            var temperatureData = new List<TemperatureModel>
            {
                new TemperatureModel(0, 3, DateTime.Parse("2021 - 03 - 11 08:02:34")),
                new TemperatureModel(1, 4, DateTime.Parse("2021 - 03 - 11 08:02:34")),
            };

            return temperatureData;
        }



    }
}
