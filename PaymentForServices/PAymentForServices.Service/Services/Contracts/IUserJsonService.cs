using System;
namespace PAymentForServices.Service.Services
{
    public interface IUserJsonService
    {
        string PhoneExist(string json);
        string EmailExist(string json);
        string CreatAccount(string json);
        string AccountExist(string json);
        string LoginExist(string json);
        string GetId(string json);
        string Get(string json);
    }
}

