using AutoMapper;
using KeepItDRY.BLL.Models;

namespace KeepItDRY.BLL.Profiles
{
    public class OwnerProfile : Profile
    {
        public OwnerProfile()
        {
            CreateMap<DAL.Entities.Owner, Owner>();


            CreateMap<Owner, DAL.Entities.Owner>(MemberList.Source)
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdated, opt => opt.Ignore());
        }
    }
}
