using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace KeepItDRY.BLL.Profiles
{
    class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<DAL.Entities.Address, Models.Address>();
            CreateMap<Models.Address, DAL.Entities.Address>(MemberList.Source)
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdated, opt => opt.Ignore());
        }
    }
}
