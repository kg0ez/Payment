using System;
using PAymentForServices.Common.ModelsDto;
using System.Text.Json;
using PAymentForServices.BusinessLogic.Services;
using PAymentForServices.Common.Enums;
using System.Numerics;

namespace PAymentForServices.Service.Services
{
    public class UserJsonService: IUserJsonService
    {
        private readonly IAccountService _accountService;

        public UserJsonService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public string EmailExist(string json)
        {
            return SimilarFoundExist(json, QueryUserType.EmailExist);
        }

        public string PhoneExist(string json)
        {
            return SimilarFoundExist(json, QueryUserType.PhoneExist);
        }

        public string LoginExist(string json)
        {
            return SimilarFoundExist(json, QueryUserType.LoginExist);
        }

        public string CreatAccount(string json)
        {
            var registrationDto = JsonSerializer.Deserialize<RegistrationDto>(json);

            var isCreated = _accountService.Sync(registrationDto);

            var response = JsonSerializer.Serialize<bool>(isCreated);

            return response;
        }

        public string AccountExist(string json)
        {
            var loginDto = JsonSerializer.Deserialize<LoginDto>(json);

            var exist = _accountService.Get(loginDto);

            var response = JsonSerializer.Serialize<bool>(exist);

            return response;
        }

        public string GetId(string json)
        {
            var login = JsonSerializer.Deserialize<string>(json);

            var id = _accountService.GetId(login);

            var response = JsonSerializer.Serialize<int>(id);

            return response;
        }

        public string Get(string json)
        {
            var id = JsonSerializer.Deserialize<int>(json);

            var user = _accountService.GetUser(id);

            var response = JsonSerializer.Serialize<UserDto>(user);

            return response;
        }

        private string SimilarFoundExist(string json, QueryUserType type)
        {
            var userData = JsonSerializer.Deserialize<string>(json)!;

            bool exist = false;

            if (type == QueryUserType.EmailExist)
                exist = _accountService.EmailExist(userData);

            else if (type == QueryUserType.PhoneExist)
                exist = _accountService.PhoneExist(userData);

            else if (type == QueryUserType.LoginExist)
                exist = _accountService.LoginExist(userData);

            var response = JsonSerializer.Serialize<bool>(exist);

            return response;
        }
    }
}

