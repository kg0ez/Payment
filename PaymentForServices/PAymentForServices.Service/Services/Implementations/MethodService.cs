using System;
using System.Text.Json;
using AutoMapper;
using PAymentForServices.BusinessLogic.Services;
using PAymentForServices.Common.ModelsDto;

namespace PAymentForServices.Service.Services
{
    public class MethodService: IMethodService
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly ICategoryService _categoryService;
        private readonly IHistoryPaymentService _historyPayment;

        public MethodService(
            IMapper mapper,
            IAccountService accountService,
            ICategoryService categoryService,
            IHistoryPaymentService historyPayment)
        {
            _mapper = mapper;
            _accountService = accountService;
            _categoryService = categoryService;
            _historyPayment = historyPayment;
        }

        //public string ExistEmail(string json)
        //{
        //    var email = JsonSerializer.Deserialize<string>(json);

        //    var exist = _accountService.EmailExist(email);

        //    var response = JsonSerializer.Serialize<bool>(exist);

        //    return response;
        //}

        //public string ExistPhone(string json)
        //{
        //    var phone = JsonSerializer.Deserialize<string>(json);

        //    var exist = _accountService.PhoneExist(phone);

        //    var response = JsonSerializer.Serialize<bool>(exist);

        //    return response;
        //}

        //public string CreatAccount(string json)
        //{
        //    var registrationDto = JsonSerializer.Deserialize<RegistrationDto>(json);

        //    var isCreated = _accountService.Sync(registrationDto);

        //    var response = JsonSerializer.Serialize<bool>(isCreated);

        //    return response;
        //}

        //public string ExistAccount(string json)
        //{
        //    var loginDto = JsonSerializer.Deserialize<LoginDto>(json);

        //    var exist = _accountService.Get(loginDto);

        //    var response = JsonSerializer.Serialize<bool>(exist);

        //    return response;
        //}

        //public string ExistLogin(string json)
        //{
        //    var login = JsonSerializer.Deserialize<string>(json);

        //    var exist = _accountService.LoginExist(login);

        //    var response = JsonSerializer.Serialize<bool>(exist);

        //    return response;
        //}
        //public string GetUserId(string json)
        //{
        //    var login = JsonSerializer.Deserialize<string>(json);

        //    var id = _accountService.GetId(login);

        //    var response = JsonSerializer.Serialize<int>(id);

        //    return response;
        //}
        //public string GetUser(string json)
        //{
        //    var id = JsonSerializer.Deserialize<int>(json);

        //    var user = _accountService.GetUser(id);

        //    var response = JsonSerializer.Serialize<UserDto>(user);

        //    return response;
        //}

        //public string GetServices()
        //{
        //    var services = _categoryService.GetServices();

        //    var response = JsonSerializer.Serialize<List<ServiceDto>>(services);

        //    return response;
        //}

        //public string GetCategories(string json)
        //{
        //    var id = JsonSerializer.Deserialize<int>(json);

        //    var services = _categoryService.GetCategories(id);

        //    var response = JsonSerializer.Serialize<List<CategoryDto>>(services);

        //    return response;
        //}

        //public string GetCategoryId(string json)
        //{
        //    var name = JsonSerializer.Deserialize<string>(json);

        //    var id = _categoryService.GetCategoryId(name);

        //    var response = JsonSerializer.Serialize<int>(id);

        //    return response;
        //}

        //public string GetHistoryPayment(string json)
        //{
        //    var userId = JsonSerializer.Deserialize<int>(json);

        //    var payments = _historyPayment.Get(userId);

        //    var response = JsonSerializer.Serialize<List<HistoryPaymentDto>>(payments);

        //    return response;
        //}
        //public string SyncHistoryPayment(string json)
        //{
        //    var paymentDto = JsonSerializer.Deserialize<HistoryPaymentDto>(json);

        //    var result = _historyPayment.Sync(paymentDto);

        //    var response = JsonSerializer.Serialize<bool>(result);

        //    return response;
        //}

        //public string DeleteHistoryPayment(string json)
        //{
        //    var id = JsonSerializer.Deserialize<int>(json);

        //    var result = _historyPayment.Delete(id);

        //    var response = JsonSerializer.Serialize<bool>(result);

        //    return response;
        //}
    }
}

