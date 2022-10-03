using System;
using System.Text.Json;
using AutoMapper;
using PAymentForServices.BusinessLogic.Services;
using PAymentForServices.Common.Enums;
using PAymentForServices.Common.Server;
using PAymentForServices.Service.Services;

namespace PAymentForServices.Service.Handler
{
    public static class TypeHandler
    {
        public static string SearchType(
            ServerQuery query,
            IMethodService methodService)
        {

            if (query.Type == QueryType.User)
            {
                var nameMethod = JsonSerializer.Deserialize<QueryUserType>(query.TypeAction);
                return methodService.User(nameMethod, query.Object);
            }

            else if (query.Type == QueryType.HistoryPayment)
            {
                var nameMethod = JsonSerializer.Deserialize<QueryHistoryPaymentType>(query.TypeAction);
                return methodService.HistoryPayment(nameMethod, query.Object);
            }

            else if (query.Type == QueryType.Category)
            {
                var nameMethod = JsonSerializer.Deserialize<QueryCategoryType>(query.TypeAction);
                return methodService.Category(nameMethod, query.Object);
            }

            throw new Exception("Type wasn`t found");
        }
    }
}

