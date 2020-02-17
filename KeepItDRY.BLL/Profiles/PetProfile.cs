using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace KeepItDRY.BLL.Profiles
{
    class PetProfile : Profile
    {
        public PetProfile()
        {
            CreateMap<DAL.Entities.Pet, Models.Pet>();
            CreateMap<Models.Pet, DAL.Entities.Pet>(MemberList.Source)
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdated, opt => opt.Ignore());
        }
    }
}
