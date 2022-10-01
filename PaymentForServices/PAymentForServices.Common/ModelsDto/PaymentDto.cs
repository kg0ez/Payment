using System;
namespace PAymentForServices.Common.ModelsDto
{
    public class PaymentDto:UserDto
    {
        public string NameService { get; set; }
        public string CodeService { get; set; }
        public int PaymentAmount { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}

