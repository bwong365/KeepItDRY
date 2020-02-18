using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KeepItDRY.DAL.Entities
{
    public partial class Owner : IEntity
    {
        [Key]
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
