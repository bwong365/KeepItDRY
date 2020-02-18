using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KeepItDRY.API.DTO
{
    public class OwnerDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(80)]
        public string LastName { get; set; }
        public List<PetDTO> Pets { get; set; }
    }
}
