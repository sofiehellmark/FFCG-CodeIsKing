
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WeatherApi.Test
{
    [TestFixture]
    public class TestEndpoint : TestBase
    {
        private List<TemperatureModel> _result;
        private HttpResponseMessage _response;
        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            _response = await HttpClient.GetAsync("/weatherforecast");
            _result = await _response.Content.ReadFromJsonAsync<List<TemperatureModel>>();



        }
        [Test]
        public void StatusCodeOK()
        {
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }

        [Test]
        public void CorrectTemperatureReturned()
        {

            Assert.AreEqual(3.0, _result[0].Temperature);
        }
        [Test]
        public void CorrectDateReturned()
        {
            Assert.AreEqual(DateTime.Parse("2021 - 03 - 11 08:02:34"), _result[0].Timestamp);
        }
        [Test]
        public void CorrectLengthOfList()
        {
            Assert.AreEqual(2, _result.Count);
        }
     

    }
}

