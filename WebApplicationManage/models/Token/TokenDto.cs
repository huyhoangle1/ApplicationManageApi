﻿using System.ComponentModel.DataAnnotations;

namespace WebApplicationManage.models.Token
{
    public class TokenDto
    {
        [Required]
        public string? AccessToken { get; set; }
        [Required]
        public string? RefreshToken { get; set; }
        public int UserID { get; set; }
    }
}
