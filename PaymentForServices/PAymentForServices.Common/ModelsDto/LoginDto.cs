using System;
using System.ComponentModel.DataAnnotations;

namespace PAymentForServices.Common.ModelsDto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(35, MinimumLength = 10, ErrorMessage = "Длина строки должна быть от 10 до 35 символов")]
        public string UserLogin { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "Длина строки должна быть от 7 до 15 символов")]
        public string Password { get; set; }
    }
}

