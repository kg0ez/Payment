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
            if (query.Type == QueryUserType.GetPhone)
            {
                return methodService.ExistPhone(query.Object);
            }
            else if (query.Type == QueryUserType.GetEmail)
            {
                return methodService.ExistEmail(query.Object);
            }
            else if (query.Type == QueryUserType.CreatAccount)
            {
                return methodService.CreatAccount(query.Object);
            }

            return "Not found";
        }
    }
}

