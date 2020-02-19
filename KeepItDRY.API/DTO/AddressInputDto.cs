using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KeepItDRY.API.DTO
{
    public class AddressInputDto
    {
        public string City { get; set; }
        public string Province { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]\d[a-zA-Z]\s?\d[a-zA-z]\d$")]
        public string PostalCode { get; set; }
    }
}
