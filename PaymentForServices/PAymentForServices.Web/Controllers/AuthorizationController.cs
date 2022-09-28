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
            if (ModelState.IsValid)
            {

            }
            return View(login);
        }

        [HttpPost]
        public IActionResult Registration(RegistrationDto registration)
        {
            if (ModelState.IsValid)
            {

            }

            return View(registration);
        }
    }
}

