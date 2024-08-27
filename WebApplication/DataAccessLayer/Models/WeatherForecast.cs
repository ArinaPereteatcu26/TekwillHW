using System;

namespace DataAccessLayer.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int Temperature { get; set; }

        public int TemperatureF => 32 + (int)(Temperature / 0.5556);

        public string Summary { get; set; }
    }
}
