using System.ComponentModel.DataAnnotations;

namespace KeepItDRY.DAL.Entities
{
    public partial class Pet : IPet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        [Required]
        public PetTypes PetType { get; set; }

        public Address Address { get; set; }
    }
}
