namespace KeepItDRY.BLL.Models
{
    using Newtonsoft.Json;

    public partial class LocationCodeResponse
    {
        [JsonProperty("Version")]
        public int Version { get; set; }

        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Rank")]
        public long Rank { get; set; }

        [JsonProperty("LocalizedName")]
        public string LocalizedName { get; set; }

        [JsonProperty("EnglishName")]
        public string EnglishName { get; set; }

        [JsonProperty("PrimaryPostalCode")]
        public string PrimaryPostalCode { get; set; }

        [JsonProperty("Region")]
        public Region Region { get; set; }

        [JsonProperty("Country")]
        public Region Country { get; set; }

        [JsonProperty("AdministrativeArea")]
        public AdministrativeArea AdministrativeArea { get; set; }

        [JsonProperty("TimeZone")]
        public TimeZone TimeZone { get; set; }

        [JsonProperty("GeoPosition")]
        public GeoPosition GeoPosition { get; set; }

        [JsonProperty("IsAlias")]
        public bool IsAlias { get; set; }

        [JsonProperty("ParentCity")]
        public ParentCity ParentCity { get; set; }

        [JsonProperty("SupplementalAdminAreas")]
        public object[] SupplementalAdminAreas { get; set; }

        [JsonProperty("DataSets")]
        public string[] DataSets { get; set; }
    }

    public partial class AdministrativeArea
    {
        [JsonProperty("ID")]
        public string Id { get; set; }

        [JsonProperty("LocalizedName")]
        public string LocalizedName { get; set; }

        [JsonProperty("EnglishName")]
        public string EnglishName { get; set; }

        [JsonProperty("Level")]
        public long Level { get; set; }

        [JsonProperty("LocalizedType")]
        public string LocalizedType { get; set; }

        [JsonProperty("EnglishType")]
        public string EnglishType { get; set; }

        [JsonProperty("CountryID")]
        public string CountryId { get; set; }
    }

    public partial class Region
    {
        [JsonProperty("ID")]
        public string Id { get; set; }

        [JsonProperty("LocalizedName")]
        public string LocalizedName { get; set; }

        [JsonProperty("EnglishName")]
        public string EnglishName { get; set; }
    }

    public partial class GeoPosition
    {
        [JsonProperty("Latitude")]
        public double Latitude { get; set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; set; }

        [JsonProperty("Elevation")]
        public Elevation Elevation { get; set; }
    }

    public partial class Elevation
    {
        [JsonProperty("Metric")]
        public Measurement Metric { get; set; }

        [JsonProperty("Imperial")]
        public Measurement Imperial { get; set; }
    }

    public partial class ParentCity
    {
        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("LocalizedName")]
        public string LocalizedName { get; set; }

        [JsonProperty("EnglishName")]
        public string EnglishName { get; set; }
    }

    public partial class TimeZone
    {
        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("GmtOffset")]
        public object GmtOffset { get; set; }

        [JsonProperty("IsDaylightSaving")]
        public bool IsDaylightSaving { get; set; }

        [JsonProperty("NextOffsetChange")]
        public object NextOffsetChange { get; set; }
    }
}
