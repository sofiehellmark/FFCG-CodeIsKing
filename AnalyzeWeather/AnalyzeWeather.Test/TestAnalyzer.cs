using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnalyzeWeather.Test
{
    [TestClass]
    public class TestAnalyzer
    {
        private TemperatureAnalyzer _temperatureAnalyzer;
        private List<TemperatureModel> _temperatureData;
        private List<TemperatureModel> _temperatureDataDay;
        private List<TemperatureModel> _temperatureDataNight;

        [TestInitialize]
        public void Setup()
        {

            _temperatureDataDay = new List<TemperatureModel>
            {
                // DAY

                new TemperatureModel(0, 3, DateTime.Parse("2021 - 03 - 11 08:02:34")),
                new TemperatureModel(0, 4, DateTime.Parse("2021 - 03 - 11 09:02:34")),
                new TemperatureModel(0, 5, DateTime.Parse("2021 - 03 - 11 10:02:34")),
                // NIGHT
                new TemperatureModel(0, 0, DateTime.Parse("2021 - 03 - 11 04:02:34")),
                new TemperatureModel(0, 1, DateTime.Parse("2021 - 03 - 11 03:02:34")),
                new TemperatureModel(0, 2, DateTime.Parse("2021 - 05 - 11 02:02:34"))
            };
            // _temperatureData = (List<TemperatureModel>)_temperatureDataDay.Concat(_temperatureDataNight);
            _temperatureAnalyzer = new TemperatureAnalyzer();


        }
        [TestMethod]
        public void TestAverage()
        {

            var result = _temperatureAnalyzer.CheckAverage(_temperatureDataDay);
            Assert.AreEqual(2.5, result, "Average not correct");

        }
        [TestMethod]
        public void TestMax()
        {

            var result = _temperatureAnalyzer.CheckMax(_temperatureDataDay);
            Assert.AreEqual(5.0, result, "Max not correct");

        }
        [TestMethod]
        public void TestMin()
        {

            var result = _temperatureAnalyzer.CheckMin(_temperatureDataDay);
            Assert.AreEqual(0, result, "Min not correct");

        }
        [TestMethod]
        public void TestWarmestDate()
        {

            var result = _temperatureAnalyzer.GetWarmestDate(_temperatureDataDay);
            Assert.AreEqual(DateTime.Parse("2021 - 03 - 11 10:02:34"), result, "Warmest date not correct");

        }
        [TestMethod]
        public void TestColdestDate()
        {

            var result = _temperatureAnalyzer.GetColdestDate(_temperatureDataDay);
            Assert.AreEqual(DateTime.Parse("2021 - 03 - 11 04:02:34"), result, "Coldest date not correct");

        }
        [TestMethod]
        public void TestDateSplit()
        {
            var startDate = DateTime.Parse("2021 - 02 - 11");
            var endDate = DateTime.Parse("2021 - 04 - 11");

            var result = _temperatureAnalyzer.SplitOnDate(_temperatureDataDay, startDate, endDate);
            Assert.AreEqual(5, result.Count);

        }
        [TestMethod]
        public void TestHourSplit()
        {
            var startHour = 8;
            var endHour = 9;

            var result = _temperatureAnalyzer.SplitOnHours(_temperatureDataDay, startHour, endHour);
            Assert.AreEqual(1, result.Count);

        }

        [TestMethod]
        public void TestUnixToDateTime()
        {
            long unixTime = 1616942783000; 
            System.DateTime dtDateTime = new DateTime(2021, 03, 28, 16, 46, 23, 0);
            var result = new ConvertSMHIData().UnixToDateTime(unixTime);
            Assert.AreEqual(result, dtDateTime);
        }
    }
}
