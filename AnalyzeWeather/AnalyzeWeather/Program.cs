using System;
using System.Collections.Generic;


namespace AnalyzeWeather
{
    

    class Program
    {
        
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("FILE");

            var path = "/Users/sofie.hellmark/Projects/AnalyzeWeather/temperatures.csv";
            List<TemperatureModel> TemperatureData = await new CsvToTemperatureReader(path).GetData();
            var report = new WeatherReport(TemperatureData).GetReport();
            Console.WriteLine(report);

            Console.WriteLine("SMHI");
            var Sthlm = 98230;
            var Lund = 53430;
            List<TemperatureModel> TemperatureDataSmhi = await new SMHIDataToTemperatureReader(Lund).GetData();
            var smhireport = new WeatherReport(TemperatureDataSmhi).GetReport();

            Console.WriteLine(smhireport);




        }
    }
}

