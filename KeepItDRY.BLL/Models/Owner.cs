using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KeepItDRY.BLL.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(80)]
        public string LastName { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
