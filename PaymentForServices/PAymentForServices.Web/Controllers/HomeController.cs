using System.Diagnostics;
using System.Text.Json;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using PAymentForServices.Common.Enums;
using PAymentForServices.Common.ModelsDto;
using PAymentForServices.Web.Handler;
using PAymentForServices.Web.Models;

namespace PAymentForServices.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult MainPage()
    {
        return View();
    }
    public IActionResult HistoryPaymentPage()
    {
        string json = QueryHandler<int>.Serialize(Models.UserAccount.Id, QueryUserType.GetHistoryPayments);

        string answer = NetworkHandler.Client(json);

        var historyPayment = JsonSerializer.Deserialize<List<HistoryPaymentDto>>(answer);

        //var hp = new List<HistoryPaymentDto>
        //{
        //    new HistoryPaymentDto
        //    {
        //        Category = new CategoryDto{ Name =  "Билеты Белавиа, ЖД"    },
        //        PaymentAmount = 110,
        //        User = new UserDto{ Name= "Кирилл", LastName="Бовбель",Partonymic="Александрович"},
        //        CreatAt = DateTime.Now
        //    },new HistoryPaymentDto
        //    {
        //        Category = new CategoryDto{ Name =  "Билеты Белавиа, ЖД"    },
        //        PaymentAmount = 110,
        //        User = new UserDto{ Name= "Кирилл", LastName="Бовбель",Partonymic="Александрович"},
        //        CreatAt = DateTime.Now
        //    },
        //};
        return View(historyPayment);
    }
}

