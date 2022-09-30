using System;
using System.ComponentModel.DataAnnotations;

namespace PAymentForServices.Common.ModelsDto
{
    public class LoginDto
    {
        public string UserLogin { get; set; }
        public string Password { get; set; }
    }
}

