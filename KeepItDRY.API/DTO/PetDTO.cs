using System;
using System.ComponentModel.DataAnnotations;
using KeepItDRY.BLL.Models;

namespace KeepItDRY.API.DTO
{
    public class PetDTO
    {
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        public int Id { get; set; }

        [Required]
        public string PetType { get; set; }
        public Address Address { get; set; }
        public int OwnerId { get; set; }

        public bool HasValidPetType() => Enum.TryParse<DAL.Entities.PetTypes>(PetType, true, out _);

    }
}
