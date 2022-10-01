using System;
using PAymentForServices.Common.ModelsDto;

namespace PAymentForServices.BusinessLogic.Services
{
    public interface IAccountService
    {
        bool Sync(RegistrationDto registrationDto);
        bool EmailExist(string email);
        bool PhoneExist(string phone);
        bool Get(LoginDto login);
        bool LoginExist(string login);
        int GetId(string login);
        UserDto GetUser(int Id);
    }
}

