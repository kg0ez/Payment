using System;
using System.ComponentModel.DataAnnotations;

namespace PAymentForServices.Common.ModelsDto
{
    public class LoginDto
    {
        [Required]
        public string UserLogin { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

