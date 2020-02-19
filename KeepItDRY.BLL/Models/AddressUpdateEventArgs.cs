using System;
using System.Collections.Generic;
using System.Text;

namespace KeepItDRY.BLL.Models
{
    public class AddressUpdateEventArgs
    {
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
    }
}
