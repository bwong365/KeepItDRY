using System;
using System.Collections.Generic;
using System.Text;

namespace KeepItDRY.DAL.Entities
{
    public enum PetType
    {
        DOG, CAT, TURTLE, PLAYTPUS, CAMEL, PARROT
    }

    public interface IPet : IEntity
    {
        public string Name { get; set; }
        public PetType PetType { get; set; }
        public Address Address { get; set; }
    }
}
