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

        string GetServices();
        string GetCategories(string json);
    }
}

