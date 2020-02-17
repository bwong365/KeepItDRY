using System;

namespace KeepItDRY.DAL.Entities
{
    public partial class Address : IStandardEntity
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
