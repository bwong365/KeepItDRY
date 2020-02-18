using System;
using Newtonsoft.Json;

namespace KeepItDRY.BLL.Models
{

    public class CurrentConditionsResponse
    {
        [JsonProperty("LocalObservationDateTime")]
        public DateTimeOffset LocalObservationDateTime { get; set; }

        [JsonProperty("EpochTime")]
        public long EpochTime { get; set; }

        [JsonProperty("WeatherText")]
        public string WeatherText { get; set; }

        [JsonProperty("WeatherIcon")]
        public long WeatherIcon { get; set; }

        [JsonProperty("HasPrecipitation")]
        public bool HasPrecipitation { get; set; }

        [JsonProperty("PrecipitationType")]
        public string PrecipitationType { get; set; }

        [JsonProperty("IsDayTime")]
        public bool IsDayTime { get; set; }

        [JsonProperty("Temperature")]
        public Temperature Temperature { get; set; }

        [JsonProperty("MobileLink")]
        public Uri MobileLink { get; set; }

        [JsonProperty("Link")]
        public Uri Link { get; set; }
    }

    public partial class Temperature
    {
        [JsonProperty("Metric")]
        public Measurement Metric { get; set; }

        [JsonProperty("Imperial")]
        public Measurement Imperial { get; set; }
    }

    public partial class Measurement
    {
        [JsonProperty("Value")]
        public double Value { get; set; }

        [JsonProperty("Unit")]
        public string Unit { get; set; }

        [JsonProperty("UnitType")]
        public long UnitType { get; set; }
    }
}
