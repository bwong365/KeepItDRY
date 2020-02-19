using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using KeepItDRY.BLL.Models;

namespace KeepItDRY.BLL.Profiles
{
    public class WeatherProfile : Profile
    {
        public WeatherProfile()
        {
            CreateMap<CurrentConditionsResponse, WeatherStatus>()
                .ForMember(dest => dest.Temperature, 
                           opt => opt.MapFrom(source => source.Temperature.Metric.Value));
        }
    }
}
