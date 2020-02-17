using System;
using AutoMapper;
using KeepItDRY.API.DTO;
using KeepItDRY.BLL.Models;

namespace KeepItDRY.API.Profiles
{
    public class PetDTOProfile : Profile
    {
        public PetDTOProfile()
        {
            CreateMap<PetDTO, Pet>()
                .ForMember(dest => dest.PetType,
                           opt => opt.MapFrom(p => (DAL.Entities.PetTypes)Enum.Parse(typeof(DAL.Entities.PetTypes), p.PetType, true)));

            CreateMap<Pet, PetDTO>().ForMember(dest => dest.PetType, opt => opt.MapFrom(p => p.PetType.ToString()));

        }
    }
}
