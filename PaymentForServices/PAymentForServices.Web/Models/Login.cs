using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PAymentForServices.Web.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(35, MinimumLength = 10, ErrorMessage = "Длина строки должна быть от 10 до 35 символов")]
        [Remote(action: "CheckLogin", controller: "Authorization", ErrorMessage = "Пользователь с таким логином не найден")]
        public string UserLogin { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "Длина строки должна быть от 7 до 15 символов")]
        //[Remote(action: "CheckAccount", controller: "Authorization", ErrorMessage = "Пользователь с таким логином или паролем не найден")]
        public string Password { get; set; }
    }
}

