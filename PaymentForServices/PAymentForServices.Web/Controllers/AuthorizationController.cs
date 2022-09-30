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
        private readonly IJsonService _jsonService;
        private readonly IMapper _mapper;

        public AuthorizationController(IJsonService jsonService, IMapper mapper)
        {
            _jsonService = jsonService;
            _mapper = mapper;
        }

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
        public IActionResult Registration(Registration registration)
        {
            if (!ModelState.IsValid)
                return View(registration);

            RegistrationDto dto = _mapper.Map<RegistrationDto>(registration);

            string json = QueryHandler<RegistrationDto>.Serialize(dto, QueryUserType.CreatAccount);

            string answer = NetworkHandler.Client(json);

            var exist = JsonSerializer.Deserialize<bool>(answer);

            if (exist)
                return RedirectPermanent("~/Service/Services");
            return View(registration);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckEmail(string Email)
        {
            string json = QueryHandler<string>.Serialize(Email, QueryUserType.GetEmail);

            string answer = NetworkHandler.Client(json);

            var exist = JsonSerializer.Deserialize<bool>(answer);

            if (exist)
                return Json(false);
            return Json(true);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckPhone(string Phone)
        {
            string json = QueryHandler<string>.Serialize(Phone, QueryUserType.GetPhone);

            string answer = NetworkHandler.Client(json);

            var exist = JsonSerializer.Deserialize<bool>(answer);

            if (exist)
                return Json(false);
            return Json(true);
        }
    }
}

