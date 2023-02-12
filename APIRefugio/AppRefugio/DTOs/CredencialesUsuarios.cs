﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppRefugio.DTOs
{
    public class CredencialesUsuarios
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
