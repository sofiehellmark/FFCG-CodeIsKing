using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
namespace WeatherApi
{
    public class CsvToTemperatureReader : IDataReader
    {
        private string _path;

        public CsvToTemperatureReader()
        {
            var path = "/Users/sofie.hellmark/Projects/AnalyzeWeather/temperatures.csv";

            _path = path;

        }

        public List<TemperatureModel> GetData()
        {
            // File must have columns id/temperature/datetime
            if (!File.Exists(_path))
            {
                Console.WriteLine("Path does not exist");

            }
            string[] file = File.ReadAllLines(_path);

            List<TemperatureModel> temperatureData = new List<TemperatureModel>();

            foreach (string row in file)
            {
                string[] values = row.Split(';');
                int id = Int32.Parse(values[0]);
                float temperature = float.Parse(values[1]);
                DateTime timestamp = DateTime.Parse(values[2]);
                temperatureData.Add(new TemperatureModel(id, temperature, timestamp));
            }

            return temperatureData;


        }

        public string GetDataAsJSON()
        {
            List<TemperatureModel> temperatureData = GetData();
            //DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<TemperatureModel>));
            //MemoryStream msObj = new MemoryStream();
            //js.WriteObject(msObj, TemperatureData);
            //msObj.Position = 0;
            //StreamReader sr = new StreamReader(msObj);

            //string json = sr.ReadToEnd();

            //sr.Close();
            //msObj.Close();
            string json = JsonConvert.SerializeObject(temperatureData, Formatting.Indented);


            return json;// TemperatureData[0].ToString(); 
        }

    }
}