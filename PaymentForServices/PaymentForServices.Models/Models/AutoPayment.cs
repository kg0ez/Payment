using System;

namespace PaymentForServices.Models.Models
{
    public class AutoPayment
    {
        public int Id { get; set; }

        public string Phone { get; set; }

        public decimal PaymentAmount { get; set; }

        public decimal ThresholdAmount { get; set; }

        public string PhoneNotification { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}

