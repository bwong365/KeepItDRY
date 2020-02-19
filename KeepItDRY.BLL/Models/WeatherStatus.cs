using System;
using System.Collections.Generic;
using System.Text;

namespace KeepItDRY.BLL.Models
{
    public class WeatherStatus
    {
        public DateTimeOffset LocalObservationDateTime { get; set; }
        public string WeatherText { get; set; }
        public bool HasPrecipitation { get; set; }
        public string PrecipitationType { get; set; }
        public bool IsDayTime { get; set; }
        public double Temperature { get; set; }
        public string TemperatureUnit { get; set; } = "C";
    }
}
