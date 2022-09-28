using System;
using System.ComponentModel.DataAnnotations;

namespace PAymentForServices.Common.ModelsDto
{
    public class RegistrationDto
    {
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Partonymic { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Emain { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Phone { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}

