using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using KeepItDRY.DAL.Entities;

namespace KeepItDRY.BLL.Profiles
{
    public class OwnerProfile : Profile
    {
        public OwnerProfile()
        {
            CreateMap<Owner, Owner>();
        }
    }
}
