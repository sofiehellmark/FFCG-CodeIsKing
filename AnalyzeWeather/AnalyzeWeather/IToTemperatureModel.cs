using System;
using System.Collections.Generic;

namespace AnalyzeWeather
{
    public interface IToTemperatureModel
    {
        List<TemperatureModel> TemperatureData { get; }
    }
}
