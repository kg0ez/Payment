using System;
namespace PAymentForServices.Service.Services
{
    public interface ICategoryJsonService
    {
        string GetServices();
        string Get(string json);
        string GetId(string json);
    }
}

