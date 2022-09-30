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
        }
    }
}

