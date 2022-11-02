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
            var typeAction = QueryHandler<QueryCategoryType>.QueryTypeSerialize(QueryCategoryType.GetServices);

            string json = QueryHandler<string>.Serialize("", QueryType.Category, typeAction);

            string answer = NetworkHandler.ConnectionWithServ(json);

            var services = JsonSerializer.Deserialize<List<ServiceDto>>(answer);

            var typeServices = _mapper.Map<List<TypeService>>(services);

            UserAccount.ServiceId = default;

            return View(typeServices);
        }

        [HttpPost]
        public IActionResult Services(int Id)
        {
            if (Id==0 && UserAccount.ServiceId !=0)
                Id = UserAccount.ServiceId;

            else if (Id == 0 && UserAccount.ServiceId == 0)
                return RedirectToActionPermanent("Services", "Service");

            var typeAction = QueryHandler<QueryCategoryType>.QueryTypeSerialize(QueryCategoryType.GetCategoris);

            string json = QueryHandler<int>.Serialize(Id, QueryType.Category,typeAction);

            string answer = NetworkHandler.ConnectionWithServ(json);

            var categories = JsonSerializer.Deserialize<List<CategoryDto>>(answer);

            var typeServices = _mapper.Map<List<TypeService>>(categories);

            UserAccount.ServiceId = Id;

            return View(typeServices);
        }

        [HttpPost]
        public IActionResult Category(string category)
        {
            return RedirectToActionPermanent("Payment", "Service", new { nameCategory = category});
        }

        [HttpPost]
        public IActionResult Cancel()
        {
            return RedirectToActionPermanent("Services", "Service");
        }

        public IActionResult Payment(string nameCategory)
        {
            var user = QueryHandler<int>.QueryGetUser(Models.UserAccount.Id);

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
            var typeAction = QueryHandler<QueryCategoryType>.QueryTypeSerialize(QueryCategoryType.GetCategoryId);

            string json = QueryHandler<string>.Serialize(payment.NameService, QueryType.Category, typeAction);

            string answer = NetworkHandler.ConnectionWithServ(json);

            var categoryId = JsonSerializer.Deserialize<int>(answer);

            var history = new HistoryPaymentDto
            {
                CategoryId = categoryId,
                UserId = Models.UserAccount.Id,
                PaymentAmount = Convert.ToDecimal(payment.PaymentAmount.Replace('.',',')),
                CodeTransaction = payment.CodeTransaction
            };

            typeAction = QueryHandler<QueryHistoryPaymentType>.QueryTypeSerialize(QueryHistoryPaymentType.SyncHistoryPayment);

            json = QueryHandler<HistoryPaymentDto>.Serialize(history, QueryType.HistoryPayment, typeAction);

            answer = NetworkHandler.ConnectionWithServ(json);

            var isSaved = JsonSerializer.Deserialize<bool>(answer);

            if (isSaved)
                return RedirectPermanent("~/Service/Services");

            return View(payment);
        }

        public IActionResult AutoPayment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AutoPayment(Web.Models.AutoPayment autoPayment)
        {
            if (autoPayment.Phone is null)
                return View();

            var autoPaymentDto = _mapper.Map<AutoPaymentDto>(autoPayment);
            string typeAction = QueryHandler<QueryHistoryPaymentType>.QueryTypeSerialize(QueryHistoryPaymentType.AutoPaymentSyncHistoryPayment);

            string json = QueryHandler<AutoPaymentDto>.Serialize(autoPaymentDto, QueryType.HistoryPayment, typeAction);

            string answer = NetworkHandler.ConnectionWithServ(json);
            var isSaved = JsonSerializer.Deserialize<bool>(answer);

            if (isSaved)
                return RedirectPermanent("~/Service/Services");
            return View();
        }
    }
}

