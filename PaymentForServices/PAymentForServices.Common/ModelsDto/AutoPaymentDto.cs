using System;

namespace PAymentForServices.Common.ModelsDto
{
    public class AutoPaymentDto
    {
        public int Id { get; set; }

        public string Phone { get; set; }

        public decimal PaymentAmount { get; set; }

        public decimal ThresholdAmount { get; set; }

        public string PhoneNotification { get; set; }

        public int UserId { get; set; }
        //public UserDto User { get; set; }
    }
}

