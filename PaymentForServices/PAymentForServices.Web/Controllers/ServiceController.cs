using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PAymentForServices.Common.ModelsDto;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAymentForServices.Web.Controllers
{
    public class ServiceController : Controller
    {
        List<string> services = new List<string>
        {
            "Билеты, лотереи",
            "Финансовые услуги",
        };
        PaymentDto payment = new PaymentDto { Name = "Кирилл", LastName = "Бовбель", NameService= "ЖД билеты" }; 
        public IActionResult Services()
        {
            return View(services);
        }

        [HttpPost]
        public IActionResult Services(string service)
        {
            return View();
        }

        public IActionResult Payment()
        {
            return View(payment);
        }

        [HttpPost]
        public IActionResult Payment(PaymentDto payment)
        {
            return View();
        }
    }
}

