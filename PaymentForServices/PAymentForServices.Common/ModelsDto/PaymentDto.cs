using System;
namespace PAymentForServices.Common.ModelsDto
{
    public class PaymentDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CodeService { get; set; }
        public string NameService { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}

