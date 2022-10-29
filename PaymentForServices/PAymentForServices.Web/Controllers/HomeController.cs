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
        var typeAction = QueryHandler<QueryHistoryPaymentType>.QueryTypeSerialize(QueryHistoryPaymentType.GetHistoryPayments);

        string json = QueryHandler<int>.Serialize(UserAccount.Id, QueryType.HistoryPayment, typeAction);

        string answer = NetworkHandler.ConnectionWithServ(json);

        var historyPayment = JsonSerializer.Deserialize<List<HistoryPaymentDto>>(answer);

        return View(historyPayment);
    }

    [HttpPost]
    public IActionResult Trash(int historyId)
    {
        var typeAction = QueryHandler<QueryHistoryPaymentType>.QueryTypeSerialize(QueryHistoryPaymentType.DeleteHistoryPayment);

        string json = QueryHandler<int>.Serialize(historyId, QueryType.HistoryPayment, typeAction);

        string answer = NetworkHandler.ConnectionWithServ(json);

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

