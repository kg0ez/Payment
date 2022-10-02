using System;
namespace PAymentForServices.Service.Services
{
    public interface IMethodService
    {
        string ExistPhone(string json);
        string ExistEmail(string json);
        string CreatAccount(string json);
        string ExistAccount(string json);
        string ExistLogin(string json);
        string GetUserId(string json);
        string GetUser(string json);

        string GetServices();
        string GetCategories(string json);
        string GetCategoryId(string json);

        string GetHistoryPayment(string json);
        string SyncHistoryPayment(string json);
        string DeleteHistoryPayment(string json);
    }
}

