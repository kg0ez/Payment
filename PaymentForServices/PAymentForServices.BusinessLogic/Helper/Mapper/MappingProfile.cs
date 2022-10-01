using System;
using AutoMapper;
using PaymentForServices.Models.Models;
using PAymentForServices.Common.ModelsDto;

namespace PAymentForServices.BusinessLogic.Helper.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, RegistrationDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Service, ServiceDto>().ReverseMap();
            CreateMap<User, UserDto>();
            CreateMap<HistoryPayment, HistoryPaymentDto>().ReverseMap();
        }
    }
}

