using System;
using System.ComponentModel.DataAnnotations;

namespace PAymentForServices.Common.ModelsDto
{
    public class RegistrationDto
    {
        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Partonymic { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}

