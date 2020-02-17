using System;
using System.Collections.Generic;
using System.Text;

namespace KeepItDRY.BLL.Models
{
    public class Address
    {
        public int Id { get; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
