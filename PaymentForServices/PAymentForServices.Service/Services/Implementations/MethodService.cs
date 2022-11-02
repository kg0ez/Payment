using System;
using System.Text.Json;
using AutoMapper;
using PAymentForServices.BusinessLogic.Services;
using PAymentForServices.Common.Enums;
using PAymentForServices.Common.ModelsDto;
using PAymentForServices.Common.Server;

namespace PAymentForServices.Service.Services
{
    public class MethodService: IMethodService
    {
        private readonly IUserJsonService _userJsonService;
        private readonly ICategoryJsonService _categoryJsonService;
        private readonly IHistoryPaymentJsonService _hpJsonService;

        public MethodService(
            IUserJsonService userJsonService,
            ICategoryJsonService categoryJsonService,
            IHistoryPaymentJsonService historyPaymentJsonService)
        {
            _userJsonService = userJsonService;
            _categoryJsonService = categoryJsonService;
            _hpJsonService = historyPaymentJsonService;
        }

        public string User(QueryUserType query, string obj)
        {
            if (query == QueryUserType.PhoneExist)
                return _userJsonService.PhoneExist(obj);
            
            else if (query == QueryUserType.EmailExist)
                return _userJsonService.EmailExist(obj);
            
            else if (query == QueryUserType.CreatAccount)
                return _userJsonService.CreatAccount(obj);
            
            else if (query == QueryUserType.LoginExist)
                return _userJsonService.LoginExist(obj);
            
            else if (query == QueryUserType.GetAccount)
                return _userJsonService.AccountExist(obj);
            
            else if (query == QueryUserType.GetId)
                return _userJsonService.GetId(obj);
            
            else if (query == QueryUserType.GetUser)
                return _userJsonService.Get(obj);

            throw new Exception("User method wasn`t found");
        }

        public string Category(QueryCategoryType query, string obj)
        {
            if (query == QueryCategoryType.GetServices)
                return _categoryJsonService.GetServices();
            
            else if (query == QueryCategoryType.GetCategoris)
                return _categoryJsonService.Get(obj);
            
            else if (query == QueryCategoryType.GetCategoryId)
                return _categoryJsonService.GetId(obj);
            
            throw new Exception("Category (service) method wasn`t found");
        }

        public string HistoryPayment(QueryHistoryPaymentType query, string obj)
        {
            if (query == QueryHistoryPaymentType.GetHistoryPayments)
                return _hpJsonService.Get(obj);

            else if (query == QueryHistoryPaymentType.SyncHistoryPayment)
                return _hpJsonService.Sync(obj);

            else if (query == QueryHistoryPaymentType.DeleteHistoryPayment)
                return _hpJsonService.Delete(obj);

            else if (query == QueryHistoryPaymentType.AutoPaymentSyncHistoryPayment)
                return _hpJsonService.AutoPaymentSync(obj);

            throw new Exception("History payment method wasn`t found");
        }
    }
}

