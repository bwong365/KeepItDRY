using System;
using System.Collections.Generic;
using System.Text;

namespace KeepItDRY.BLL.Models
{
    public class Pet : IPet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PetTypes PetType { get; set; }
        public Address Address { get; set; }
    }
}
