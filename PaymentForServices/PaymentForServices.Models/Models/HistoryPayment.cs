using System;
namespace PaymentForServices.Models.Models
{
    public class HistoryPayment
    {
        public int Id { get; set; }

        public int PaymentAmount { get; set; }

        public string CodeTransaction { get; set; } = null!;

        public DateTime CreatAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

