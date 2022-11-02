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
            CreateMap<AutoPayment, AutoPaymentDto>()
                .ForMember("PaymentAmount", opt=>opt.MapFrom(opt=>Convert.ToDecimal(opt.PaymentAmount.Replace('.',','))))
                .ForMember("ThresholdAmount", opt=>opt.MapFrom(opt=>Convert.ToDecimal(opt.ThresholdAmount.Replace('.', ','))))
                .ForMember("UserId", opt=>opt.MapFrom(opt=>UserAccount.Id));
        }
    }
}

