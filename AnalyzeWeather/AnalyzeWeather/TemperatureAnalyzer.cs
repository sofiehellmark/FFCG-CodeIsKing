using System;
using System.Collections.Generic;
using System.Linq;

namespace AnalyzeWeather
{
    public class TemperatureAnalyzer
    {


        public TemperatureAnalyzer()
        {

        }

        public float CheckAverage(List<TemperatureModel> temperatureData) 
        {
            return temperatureData.Average(x => x.Temperature);
        }

        public float CheckMax(List<TemperatureModel> temperatureData)
        {
            return temperatureData.Max(x => x.Temperature);
        }
        public float CheckMin(List<TemperatureModel> temperatureData)
        {
            return temperatureData.Min(x => x.Temperature);
        }
        public DateTime CheckStartDate(List<TemperatureModel> temperatureData)
        {
            return temperatureData.Min(x => x.Timestamp.Date);
        }
        public DateTime CheckEndDate(List<TemperatureModel> temperatureData)
        {
            return temperatureData.Max(x => x.Timestamp.Date);
        }

        public DateTime GetWarmestDate(List<TemperatureModel> temperatureData)
        {
            var maxTemp = CheckMax(temperatureData);
            var itemMax = temperatureData.First(x => x.Temperature == maxTemp);
            return itemMax.Timestamp;

        }
        public DateTime GetColdestDate(List<TemperatureModel> temperatureData)
        {
            var minTemp = CheckMin(temperatureData);
            var itemMin = temperatureData.First(x => x.Temperature == minTemp);
            return itemMin.Timestamp;

        }


        public List<TemperatureModel> SplitOnDate(List<TemperatureModel> temperatureData, DateTime startDate, DateTime endDate)
        {
            var itemsInInterval = temperatureData.Where(x => (x.Timestamp.Date > startDate) && (x.Timestamp.Date <= endDate));
            return itemsInInterval.ToList();
        }


        public List<TemperatureModel> SplitOnHours(List<TemperatureModel> temperatureData, int startHour, int endHour)
        {
            if (endHour < startHour)
            {
                return temperatureData.Where(x => (x.Timestamp.Hour < endHour) || (x.Timestamp.Hour >= startHour)).ToList();

            }
            return temperatureData.Where(x => (x.Timestamp.Hour >= startHour) && (x.Timestamp.Hour < endHour)).ToList();

        }
}

}
