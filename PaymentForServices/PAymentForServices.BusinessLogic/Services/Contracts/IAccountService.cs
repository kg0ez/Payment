using System;
using PAymentForServices.Common.ModelsDto;

namespace PAymentForServices.BusinessLogic.Services
{
    public interface IAccountService
    {
        bool Sync(RegistrationDto registrationDto);
        bool GetEmail(string email);
        bool GetPhone(string phone);
    }
}

