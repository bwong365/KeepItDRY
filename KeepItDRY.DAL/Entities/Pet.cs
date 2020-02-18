using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeepItDRY.DAL.Entities
{
    public partial class Pet : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        [Required]
        public PetTypes PetType { get; set; }

        public Address Address { get; set; }

        public Owner Owner { get; set; }

        [Required]
        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
    }
}
