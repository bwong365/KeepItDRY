using System;
using System.Collections.Generic;
using System.Text;

namespace KeepItDRY.DAL.Entities
{
    public partial class Address : IEntity
    {
        public int Id { get; set;  }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
