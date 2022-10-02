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
        string json = QueryHandler<int>.Serialize(UserAccount.Id, QueryUserType.GetHistoryPayments);

        string answer = NetworkHandler.Client(json);

        var historyPayment = JsonSerializer.Deserialize<List<HistoryPaymentDto>>(answer);

        //var hp = new List<HistoryPaymentDto>
        //{
        //    new HistoryPaymentDto
        //    {
        //        Id =1,
        //        Category = new CategoryDto{ Name =  "Билеты Белавиа, ЖД"    },
        //        PaymentAmount = 110,
        //        User = new UserDto{ Name= "Кирилл", LastName="Бовбель",Partonymic="Александрович"},
        //        CreatAt = DateTime.Now,
        //        CodeTransaction = "12345"

        //    },new HistoryPaymentDto
        //    {
        //        Id= 2,
        //        Category = new CategoryDto{ Name =  "Билеты Белавиа, ЖД"    },
        //        PaymentAmount = 110,
        //        User = new UserDto{ Name= "Кирилл", LastName="Бовбель",Partonymic="Александрович"},
        //        CreatAt = DateTime.Now,
        //        CodeTransaction = "12345"
        //    },
        //};
        return View(historyPayment);
    }

    [HttpPost]
    public IActionResult Trash(int historyId)
    {
        string json = QueryHandler<int>.Serialize(historyId, QueryUserType.DeleteHistoryPayment);

        string answer = NetworkHandler.Client(json);

        var historyPayment = JsonSerializer.Deserialize<bool>(answer);

        return RedirectToActionPermanent("HistoryPaymentPage", "Home");
    }

    [HttpPost]
    public IActionResult Logout()
    {
        UserAccount.Id = 0;
        UserAccount.ServiceId = 0;
        return RedirectToActionPermanent("MainPage", "Home");
    }
}

