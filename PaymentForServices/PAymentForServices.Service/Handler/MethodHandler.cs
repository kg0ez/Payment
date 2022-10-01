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
        public static string SearchMethod(ServerQuery query, IMethodService methodService)
        {
            if (query.Type == QueryUserType.PhoneExist)
            {
                return methodService.ExistPhone(query.Object);
            }
            else if (query.Type == QueryUserType.EmailExist)
            {
                return methodService.ExistEmail(query.Object);
            }
            else if (query.Type == QueryUserType.CreatAccount)
            {
                return methodService.CreatAccount(query.Object);
            }
            else if (query.Type == QueryUserType.GetLogin)
            {
                return methodService.ExistLogin(query.Object);
            }
            else if (query.Type == QueryUserType.GetAccount)
            {
                return methodService.ExistAccount(query.Object);
            }
            else if (query.Type == QueryUserType.GetServices)
            {
                return methodService.GetServices();
            }
            else if (query.Type == QueryUserType.GetCategoris)
            {
                return methodService.GetCategories(query.Object);
            }
            return "Not found";
        }
    }
}

