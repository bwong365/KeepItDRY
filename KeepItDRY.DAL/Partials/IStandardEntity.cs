using System;

namespace KeepItDRY.DAL
{
    internal interface IStandardEntity
    {
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime LastUpdated { get; set; }
        string LastUpdatedBy { get; set; }
    }
}
