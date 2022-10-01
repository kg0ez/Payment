using System;
namespace PAymentForServices.Common.ModelsDto
{
    public class HistoryPaymentDto
    {
        public DateTime CreatAt { get; set; } = DateTime.Now;

        public int PaymentAmount { get; set; }

        public string CodeTransaction { get; set; }

        public int UserId { get; set; }
        public UserDto User { get; set; }

        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}

