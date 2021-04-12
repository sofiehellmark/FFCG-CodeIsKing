using System;
using System.Collections.Generic;

namespace AnalyzeWeather
{
    public class WeatherForecast
    {
        public List<TemperatureModelSMHI> value { get; set;  }
        public ForecastSummary period { get; set; }
    }

    public class ForecastSummary
    {
        public string summary { get; set; }
        public long to { get; set; }
        public long from { get; set; }
    }
}
