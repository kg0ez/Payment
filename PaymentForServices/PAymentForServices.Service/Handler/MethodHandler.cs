using System;
using System.Text.Json;
using AutoMapper;
using PAymentForServices.BusinessLogic.Services;
using PAymentForServices.Common.Enums;
using PAymentForServices.Common.Server;
using PAymentForServices.Service.Services;

namespace PAymentForServices.Service.Handler
{
    public static class MethodHandler
    {
        public static string SearchMethod(
            ServerQuery query,
            IMethodService methodService,
            IUserJsonService userJsonService,
            IHistoryPaymentJsonService hpJsonService,
            ICategoryJsonService categoryJsonService)
        {
            if (query.Type == QueryUserType.PhoneExist)
            {
                return userJsonService.PhoneExist(query.Object);
            }
            else if (query.Type == QueryUserType.EmailExist)
            {
                return userJsonService.EmailExist(query.Object);
            }
            else if (query.Type == QueryUserType.CreatAccount)
            {
                return userJsonService.CreatAccount(query.Object);
            }
            else if (query.Type == QueryUserType.LoginExist)
            {
                return userJsonService.LoginExist(query.Object);
            }
            else if (query.Type == QueryUserType.GetAccount)
            {
                return userJsonService.AccountExist(query.Object);
            }
            else if (query.Type == QueryUserType.GetId)
            {
                return userJsonService.GetId(query.Object);
            }
            else if (query.Type == QueryUserType.GetUser)
            {
                return userJsonService.Get(query.Object);
            }


            else if (query.Type == QueryUserType.GetServices)
            {
                return categoryJsonService.GetServices();
            }
            else if (query.Type == QueryUserType.GetCategoris)
            {
                return categoryJsonService.Get(query.Object);
            }
            else if (query.Type == QueryUserType.GetCategoryId)
            {
                return categoryJsonService.GetId(query.Object);
            }


            else if (query.Type == QueryUserType.GetHistoryPayments)
            {
                return hpJsonService.Get(query.Object);
            }
            else if (query.Type == QueryUserType.SyncHistoryPayment)
            {
                return hpJsonService.Sync(query.Object);
            }
            else if (query.Type == QueryUserType.DeleteHistoryPayment)
            {
                return hpJsonService.Delete(query.Object);
            }


            return "Not found";
        }
    }
}

