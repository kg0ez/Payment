using System;
using PAymentForServices.Common.ModelsDto;

namespace PAymentForServices.BusinessLogic.Services
{
    public interface IHistoryPaymentService
    {
        bool Sync(HistoryPaymentDto payment);
        List<HistoryPaymentDto> Get(int Id);
    }
}

