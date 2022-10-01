using System;
namespace PAymentForServices.Common.ModelsDto
{
    public class HistoryPaymentDto
    {
        public DateTime CreatAt { get; set; } = DateTime.Now;

        public int PaymentAmount { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }
    }
}

