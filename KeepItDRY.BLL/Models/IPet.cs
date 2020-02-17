using System;
using System.Collections.Generic;
using System.Text;

namespace KeepItDRY.BLL.Models
{
    public enum PetType
    {
        DOG, CAT, TURTLE, PLAYTPUS, CAMEL, PARROT
    }

    public interface IPet
    {
        public string Name { get; set; }
        public PetType PetType { get; set; }
        public Address Address { get; set; }
    }
}
