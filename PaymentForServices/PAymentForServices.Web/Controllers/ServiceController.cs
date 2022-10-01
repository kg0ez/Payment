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
using PAymentForServices.Common.Server;
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
            return RedirectToActionPermanent("Payment", "Service", new { nameCategory = category});
        }

        public IActionResult Payment(string nameCategory)
        {
            var user = QueryHandler<int>.QueryGetUser(Models.User.Id);

            var payment = new Payment
            {
                NameService = nameCategory,
                Name = user.Name,
                LastName = user.LastName,
                Partonymic = user.Partonymic,
            };
            return View(payment);
        }

        [HttpPost]
        public IActionResult Payment(Payment payment)
        {
            if (!ModelState.IsValid)
                return View(payment);

            string json = QueryHandler<string>.Serialize(payment.NameService, QueryUserType.GetCategoryId);

            string answer = NetworkHandler.Client(json);

            var categoryId = JsonSerializer.Deserialize<int>(answer);

            var history = new HistoryPaymentDto
            {
                CategoryId = categoryId,
                UserId = Models.User.Id,
                PaymentAmount = payment.PaymentAmount,
                CodeTransaction = payment.CodeTransaction
            };

            json = QueryHandler<HistoryPaymentDto>.Serialize(history, QueryUserType.SyncHistoryPayment);

            answer = NetworkHandler.Client(json);

            var isSaved = JsonSerializer.Deserialize<bool>(answer);

            if (isSaved)
                return RedirectPermanent("~/Service/Services");

            return View(payment);
        }
    }
}

