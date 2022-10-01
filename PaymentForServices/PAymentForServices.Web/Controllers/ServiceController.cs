using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaymentForServices.Models.Models;
using PAymentForServices.Common.Enums;
using PAymentForServices.Common.ModelsDto;
using PAymentForServices.Web.Handler;
using PAymentForServices.Web.Models;

namespace PAymentForServices.Web.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IMapper _mapper;

        public ServiceController(IMapper mapper)
        {
            _mapper = mapper;
        }

        PaymentDto payment = new PaymentDto { Name = "Кирилл", LastName = "Бовбель", NameService= "ЖД билеты" }; 

        public IActionResult Services()
        {
            string json = QueryHandler<string>.Serialize("", QueryUserType.GetServices);

            string answer = NetworkHandler.Client(json);

            var services = JsonSerializer.Deserialize<List<ServiceDto>>(answer);

            var typeServices = _mapper.Map<List<TypeService>>(services);

            return View(typeServices);
        }

        [HttpPost]
        public IActionResult Services(int Id)
        {
            string json = QueryHandler<int>.Serialize(Id, QueryUserType.GetCategoris);

            string answer = NetworkHandler.Client(json);

            var categories = JsonSerializer.Deserialize<List<CategoryDto>>(answer);

            var typeServices = _mapper.Map<List<TypeService>>(categories);

            return View(typeServices);
        }
        [HttpPost]
        public IActionResult Category(string category)
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

