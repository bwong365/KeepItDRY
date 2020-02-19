using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KeepItDRY.API.DTO;
using KeepItDRY.BLL.Models;

namespace KeepItDRY.API.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressInputDto, Address>();
        }
    }
}
