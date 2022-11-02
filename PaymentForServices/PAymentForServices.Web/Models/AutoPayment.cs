using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PAymentForServices.Web.Models
{
    public class AutoPayment
    {
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(15, MinimumLength = 13, ErrorMessage = "Длина строки должна быть от 13 до 15 символов")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Range(0.5, 9.9, ErrorMessage = "Недопустимая сумма")]
        public string PaymentAmount { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Range(0.1, 30, ErrorMessage = "Недопустимая сумма")]
        public string ThresholdAmount { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(15, MinimumLength = 13, ErrorMessage = "Длина строки должна быть от 13 до 15 символов")]
        public string PhoneNotification { get; set; }
    }
}

