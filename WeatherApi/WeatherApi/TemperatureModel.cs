using System;
namespace WeatherApi
{
    public class TemperatureModel
    {
        public long Id { get; }
        public float Temperature { get; }
        public DateTime Timestamp { get; }

        public TemperatureModel(long id, float temperature, DateTime timestamp)
        {
            Id = id;
            Temperature = temperature;
            Timestamp = timestamp;
        }

    }
}
