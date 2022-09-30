using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PAymentForServices.Web.Models
{
    public class Registration
    {
        
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 15 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 15 символов")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 20 символов")]
        public string Partonymic { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(35, MinimumLength = 10, ErrorMessage = "Длина строки должна быть от 10 до 35 символов")]
        [Remote(action: "CheckEmail", controller: "Authorization", ErrorMessage = "Email уже используется")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(15, MinimumLength = 13, ErrorMessage = "Длина строки должна быть от 13 до 15 символов")]
        [Remote(action: "CheckPhone", controller: "Authorization", ErrorMessage = "Телефон уже используется")]
        public string Phone { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "Длина строки должна быть от 7 до 15 символов")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "Длина строки должна быть от 7 до 15 символов")]
        public string PasswordConfirm { get; set; }
    }
}

