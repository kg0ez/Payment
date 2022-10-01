using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PAymentForServices.Web.Models;

namespace PAymentForServices.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult MainPage()
    {
        return View();
    }
}

