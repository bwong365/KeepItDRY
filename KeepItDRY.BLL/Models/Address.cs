using System.Collections.Generic;

namespace KeepItDRY.BLL.Models
{
    public class Address
    {
        private string postalCode;

        public int Id { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode
        {
            get => postalCode.Replace(" ", "");

            set => postalCode = value.Replace(" ", "");
        }
        public Owner Owner { get; set; }
        public List<Pet> Pets { get; set; }
        public int OwnerId { get; set; }
    }
}
