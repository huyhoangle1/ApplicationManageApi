﻿using System.ComponentModel.DataAnnotations;

namespace WebApplicationManage.models.User
{
    public class RegisterDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}