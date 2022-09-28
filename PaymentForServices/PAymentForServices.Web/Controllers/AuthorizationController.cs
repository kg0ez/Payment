using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PAymentForServices.Common.ModelsDto;
using PAymentForServices.Web.Models;

namespace PAymentForServices.Web.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Registration()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDto login)
        {
            return View();
        }
    }
}

