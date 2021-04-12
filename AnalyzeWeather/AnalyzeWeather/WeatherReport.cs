using System;
using System.Collections.Generic;

namespace AnalyzeWeather
{
    public class WeatherReport
    {
        private List<TemperatureModel> _temperatureData;
        public WeatherReport(List<TemperatureModel> temperatureData )
        {
            _temperatureData = temperatureData;
        }

        public string GetReport()
        {
            var analyzer = new TemperatureAnalyzer();
            // DATES


            DateTime from = analyzer.CheckStartDate(_temperatureData);
            DateTime to = analyzer.CheckEndDate(_temperatureData);

            // WARMEST COLDES DAY

            var coldestDay = analyzer.GetColdestDate(_temperatureData);
            var warmestDay = analyzer.GetWarmestDate(_temperatureData);
            var MinTemp = analyzer.CheckMin(_temperatureData);
            var MaxTemp = analyzer.CheckMax(_temperatureData);

            // AVERAGES 
            var avgTemperature = Math.Round(analyzer.CheckAverage(_temperatureData), 1);

            var startHour = 8;
            var endHour = 17;
            var TemperatureDataDay = analyzer.SplitOnHours(_temperatureData, startHour, endHour);
            var avgTemperatureDay = Math.Round(analyzer.CheckAverage(TemperatureDataDay), 1);


            startHour = 17;
            endHour = 8;
            var TemperatureDataNight = analyzer.SplitOnHours(_temperatureData, startHour, endHour);
            var avgTemperatureNight = Math.Round(analyzer.CheckAverage(TemperatureDataNight), 1);

            var report = "WEATHER REPORT \n"
                + $"Analyzed weather from {from.ToShortDateString()} to {to.ToShortDateString()}\n"
                + $"Coldest day {coldestDay}, {MinTemp}C\n"
                + $"Warmest day {warmestDay}, {MaxTemp}C\n"
                + $"Average temperature {avgTemperature}C\n"
                + $"Average temperature night {avgTemperatureNight}C\n"
                + $"Average temperature day {avgTemperatureDay}C\n";
            return report;

        }
    }
}
