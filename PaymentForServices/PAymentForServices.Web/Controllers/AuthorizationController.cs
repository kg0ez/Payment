using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PAymentForServices.Common.Enums;
using PAymentForServices.Common.ModelsDto;
using PAymentForServices.Common.Server;
using PAymentForServices.Web.Models;
using System.Text.Json;
using PAymentForServices.BusinessLogic.Services;
using PAymentForServices.Web.Handler;
using System.Numerics;
using AutoMapper;

namespace PAymentForServices.Web.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IMapper _mapper;

        public AuthorizationController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var loginDto = _mapper.Map<LoginDto>(login);

                string json = QueryHandler<LoginDto>.Serialize(loginDto, QueryUserType.GetAccount);

                string answer = NetworkHandler.Client(json);

                var exist = JsonSerializer.Deserialize<bool>(answer);

                if (exist)
                {
                    var userId = QueryHandler<string>.QueryGetId(login.UserLogin);
                    Models.UserAccount.Id = userId;

                    return RedirectPermanent("~/Service/Services");
                }

                ModelState.AddModelError("", "Неверный пароль");
            }
            return View(login);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckLogin(string UserLogin)
        {
            string json = QueryHandler<string>.Serialize(UserLogin, QueryUserType.GetLogin);

            string answer = NetworkHandler.Client(json);

            var exist = JsonSerializer.Deserialize<bool>(answer);

            if (!exist)
                return Json(false);
            return Json(true);
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(Registration registration)
        {
            if (!ModelState.IsValid)
                return View(registration);

            RegistrationDto dto = _mapper.Map<RegistrationDto>(registration);

            string json = QueryHandler<RegistrationDto>.Serialize(dto, QueryUserType.CreatAccount);

            string answer = NetworkHandler.Client(json);

            var exist = JsonSerializer.Deserialize<bool>(answer);

            if (exist)
            {
                var userId = QueryHandler<string>.QueryGetId(registration.Phone);
                Models.UserAccount.Id = userId;

                return RedirectPermanent("~/Service/Services");
            }
            return View(registration);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckEmail(string Email)
        {
            string json = QueryHandler<string>.Serialize(Email, QueryUserType.EmailExist);

            string answer = NetworkHandler.Client(json);

            var exist = JsonSerializer.Deserialize<bool>(answer);

            if (exist)
                return Json(false);
            return Json(true);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckPhone(string Phone)
        {
            string json = QueryHandler<string>.Serialize(Phone, QueryUserType.PhoneExist);

            string answer = NetworkHandler.Client(json);

            var exist = JsonSerializer.Deserialize<bool>(answer);

            if (exist)
                return Json(false);
            return Json(true);
        }
    }
}

