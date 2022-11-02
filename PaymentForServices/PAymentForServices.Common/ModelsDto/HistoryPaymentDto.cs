using System;
namespace PAymentForServices.Common.ModelsDto
{
    public class HistoryPaymentDto
    {
        public int Id { get; set; }
        public DateTime CreatAt { get; set; } = DateTime.Now;

        public decimal PaymentAmount { get; set; }

        public string CodeTransaction { get; set; }

        public int UserId { get; set; }
        public UserDto User { get; set; }

        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}

