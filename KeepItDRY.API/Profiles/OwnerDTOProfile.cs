using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KeepItDRY.API.DTO;
using KeepItDRY.BLL.Models;

namespace KeepItDRY.API.Profiles
{
    public class OwnerDTOProfile : Profile
    {
        public OwnerDTOProfile()
        {
            CreateMap<Owner, OwnerDTO>();
        }
    }
}
