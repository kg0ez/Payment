using System;
namespace PaymentForServices.Models.Models
{
    public class CreaditCard
    {
        public int Id { get; set; }

        public int Number { get; set; }
        public string Date { get; set; }
        public int CVV { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}

