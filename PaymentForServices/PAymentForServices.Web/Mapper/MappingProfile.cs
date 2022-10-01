using System;
using AutoMapper;
using PAymentForServices.Common.ModelsDto;
using PAymentForServices.Web.Models;

namespace PAymentForServices.Web.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Registration, RegistrationDto>().ReverseMap();
            CreateMap<Login, LoginDto>().ReverseMap();
            CreateMap<ServiceDto, TypeService>()
                .ForMember("NameImg", opt => opt.MapFrom(opt => "Folder.png"));
            CreateMap<CategoryDto, TypeService>()
                .ForMember("NameImg", opt => opt.MapFrom(opt => "money.png"));

        }
    }
}

