using System;
using System.Text.Json;
using AutoMapper;
using PAymentForServices.BusinessLogic.Services;
using PAymentForServices.Common.ModelsDto;

namespace PAymentForServices.Service.Services
{
    public class MethodService: IMethodService
    {
        private static IMapper _mapper;
        private static IAccountService _accountService;

        public MethodService(IMapper mapper,IAccountService accountService)
        {
            _mapper = mapper;
            _accountService = accountService;
        }

        public string ExistEmail(string json)
        {
            var email = JsonSerializer.Deserialize<string>(json);

            var exist = _accountService.EmailExist(email);

            var response = JsonSerializer.Serialize<bool>(exist);

            return response;
        }

        public string ExistPhone(string json)
        {
            var phone = JsonSerializer.Deserialize<string>(json);

            var exist = _accountService.PhoneExist(phone);

            var response = JsonSerializer.Serialize<bool>(exist);

            return response;
        }

        public string CreatAccount(string json)
        {
            var registrationDto = JsonSerializer.Deserialize<RegistrationDto>(json);

            var isCreated = _accountService.Sync(registrationDto);

            var response = JsonSerializer.Serialize<bool>(isCreated);

            return response;
        }

        public string ExistAccount(string json)
        {
            var loginDto = JsonSerializer.Deserialize<LoginDto>(json);

            var exist = _accountService.Get(loginDto);

            var response = JsonSerializer.Serialize<bool>(exist);

            return response;
        }

        public string ExistLogin(string json)
        {
            var login = JsonSerializer.Deserialize<string>(json);

            var exist = _accountService.LoginExist(login);

            var response = JsonSerializer.Serialize<bool>(exist);

            return response;
        }
    }
}

