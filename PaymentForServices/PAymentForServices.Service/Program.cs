
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PaymentForServices.Models.Data;
using PAymentForServices.BusinessLogic.Helper.Mapper;
using PAymentForServices.BusinessLogic.Services;

var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<IAccountService, AccountService>()
            .AddSingleton<ApplicationContext,ApplicationContext>()
            .BuildServiceProvider();    

var mapperConfiguration = new MapperConfiguration(x =>
{
    x.AddProfile<MappingProfile>();
});

mapperConfiguration.AssertConfigurationIsValid();
IMapper mapper = mapperConfiguration.CreateMapper();

var s = serviceProvider.GetService<IAccountService>();

s.Sync();