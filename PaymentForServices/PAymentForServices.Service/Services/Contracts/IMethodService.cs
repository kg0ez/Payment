using System;
using PAymentForServices.Common.Enums;

namespace PAymentForServices.Service.Services
{
    public interface IMethodService
    {
        string User(QueryUserType query, string obj);
        string Category(QueryCategoryType query, string obj);
        string HistoryPayment(QueryHistoryPaymentType query, string obj);
    }
}

