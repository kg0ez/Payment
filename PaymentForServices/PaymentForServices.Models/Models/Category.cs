using System;
namespace PaymentForServices.Models.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}

