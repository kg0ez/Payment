using System;
using System.ComponentModel.DataAnnotations;

namespace PAymentForServices.Web.Models
{
    public class Payment
    {
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 15 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 15 символов")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 15 символов")]
        public string Partonymic { get; set; }

        public string NameService { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 2 до 15 символов")]
        public string CodeTransaction { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Range(1,999999, ErrorMessage = "Недопустимая сумма")]
        public string PaymentAmount { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}

