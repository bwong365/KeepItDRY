using System;
using System.Collections.Generic;
using System.Text;

namespace KeepItDRY.DAL.Entities
{
    public partial class Pet : IPet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PetType PetType { get; set; }
        public Address Address { get; set; }
    }
}
