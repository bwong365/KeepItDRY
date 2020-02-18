using System;
using System.Collections.Generic;
using System.Text;

namespace KeepItDRY.DAL.Entities
{
    public partial class Owner : IStandardEntity
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
