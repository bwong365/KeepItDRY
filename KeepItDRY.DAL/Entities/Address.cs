using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeepItDRY.DAL.Entities
{
    public partial class Address : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        [Required]
        public string PostalCode { get; set; }
        public Owner Owner { get; set; }
        public List<Pet> Pets { get; set; }

        [ForeignKey("Owner")]
        [Required]
        public int OwnerId { get; set; }
    }
}
