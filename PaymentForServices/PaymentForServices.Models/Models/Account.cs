using System;
namespace PaymentForServices.Models.Models
{
    public class Account
    {
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}

