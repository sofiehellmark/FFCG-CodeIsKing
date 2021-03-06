using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherApi
{
    public interface IDataReader
    {
        Task<List<TemperatureModel>> GetData();
    }
}
