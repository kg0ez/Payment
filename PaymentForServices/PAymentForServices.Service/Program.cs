
using System.Net;
using System.Net.Sockets;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PaymentForServices.Models.Data;
using PAymentForServices.BusinessLogic.Helper.Mapper;
using PAymentForServices.BusinessLogic.Services;
using PAymentForServices.Service;
using PAymentForServices.Service.Services;

var mapperConfiguration = new MapperConfiguration(x =>
{
    x.AddProfile<MappingProfile>();
});

mapperConfiguration.AssertConfigurationIsValid();
IMapper mapper = mapperConfiguration.CreateMapper();

var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<IAccountService, AccountService>()
            .AddSingleton<IMethodService, MethodService>()
            .AddSingleton<ICategoryService, CategoryService>()
            .AddSingleton<IHistoryPaymentService, HistoryPaymentService>()
            .AddSingleton<IUserJsonService, UserJsonService>()
            .AddSingleton<IHistoryPaymentJsonService, HistoryPaymentJsonService>()
            .AddSingleton<ICategoryJsonService, CategoryJsonService>()
            .AddSingleton<ApplicationContext, ApplicationContext>()
            .AddSingleton(mapper)
            .BuildServiceProvider();    

var accountService = serviceProvider.GetService<IAccountService>();
var methodService = serviceProvider.GetService<IMethodService>();
var categoryService = serviceProvider.GetService<ICategoryService>();

var userJsonService = serviceProvider.GetService<IUserJsonService>();
var HPJsonService = serviceProvider.GetService<IHistoryPaymentJsonService>();
var categoryJsonService = serviceProvider.GetService<ICategoryJsonService>();

//accountService.Sync();
//categoryService.Sync();

TcpListener listener = null;

string IP = "127.0.0.1";
int PORT = 8080;

try
{
    listener = new TcpListener(IPAddress.Parse(IP), PORT);
    listener.Start();

    while (true)
    {
        //Для входящих
        TcpClient client = listener.AcceptTcpClient();

        ClientConnection separateCon = new ClientConnection(
            client,
            accountService,
            methodService,
            userJsonService, HPJsonService, categoryJsonService);

        Thread clientThread = new Thread(new ThreadStart(separateCon.Process));
        clientThread.Start();
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    if (listener != null)
        listener.Stop();
}