using KeepItDRY.DAL.Entities;

namespace KeepItDRY.BLL.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PetTypes PetType { get; set; }
        public Address Address { get; set; }
    }
}
