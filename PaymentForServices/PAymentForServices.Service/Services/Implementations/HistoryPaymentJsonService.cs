using System;
using PAymentForServices.Common.ModelsDto;
using PaymentForServices.Models.Models;
using System.Text.Json;
using PAymentForServices.BusinessLogic.Services;

namespace PAymentForServices.Service.Services
{
    public class HistoryPaymentJsonService : IHistoryPaymentJsonService
    {
        private readonly IHistoryPaymentService _historyPayment;

        public HistoryPaymentJsonService(IHistoryPaymentService historyPayment)
        {
            _historyPayment = historyPayment;
        }

        public string Get(string json)
        {
            var userId = JsonSerializer.Deserialize<int>(json);

            var payments = _historyPayment.Get(userId);

            var response = JsonSerializer.Serialize<List<HistoryPaymentDto>>(payments);

            return response;
        }

        public string Sync(string json)
        {
            var paymentDto = JsonSerializer.Deserialize<HistoryPaymentDto>(json)!;

            var result = _historyPayment.Sync(paymentDto);

            var response = JsonSerializer.Serialize<bool>(result);

            return response;
        }

        public string Delete(string json)
        {
            var id = JsonSerializer.Deserialize<int>(json);

            var result = _historyPayment.Delete(id);

            var response = JsonSerializer.Serialize<bool>(result);

            return response;
        }
    }
}

