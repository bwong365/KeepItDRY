using System.ComponentModel.DataAnnotations;

namespace KeepItDRY.DAL.Entities
{
    public partial class Address : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
