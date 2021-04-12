using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace AnalyzeWeather
{
    public class CsvToTemperatureReader : IDataReader
    {
        private string _path;

        public CsvToTemperatureReader(string path )
        {

            _path = path;

        }

        public async Task<List<TemperatureModel>> GetData()
        {
            // File must have columns id/temperature/datetime TODO: Throw error
            if (!File.Exists(_path))
            {
                Console.WriteLine("Path does not exist");

            }
            string[] file =  File.ReadAllLines(_path);

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

      

    }
}