using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnalyzeWeather
{
    public interface IDataReader
    {
        Task<List<TemperatureModel>> GetData();

    }
}