using System;
using System.Collections.Generic;

namespace WeatherApi
{
    internal class ConvertSMHIData
    {


        private TemperatureModel SmhiToModel(TemperatureModelSMHI dataPoint)
        {
            var temperatureModel = new TemperatureModel(dataPoint.date, float.Parse(dataPoint.value), UnixToDateTime(dataPoint.date));
            return temperatureModel;
        }

        public List<TemperatureModel> ToTemperatureModel(SMHIWeatherForecast forecast)
        {
            var temperatureData = new List<TemperatureModel>();
            foreach (var dataPoint in forecast.value)
            {
                temperatureData.Add(SmhiToModel(dataPoint));
            }
            return temperatureData;
        }

        public DateTime UnixToDateTime(long unixTime)
        {

            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixTime).ToLocalTime();
            return dtDateTime;
        }
    }
}
