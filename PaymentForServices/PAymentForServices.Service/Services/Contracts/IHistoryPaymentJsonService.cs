using System;
namespace PAymentForServices.Service.Services
{
    public interface IHistoryPaymentJsonService
    {
        string Get(string json);
        string Sync(string json);
        string Delete(string json);
        string AutoPaymentSync(string json);
    }
}

