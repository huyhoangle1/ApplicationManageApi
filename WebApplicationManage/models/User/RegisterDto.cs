using System.ComponentModel.DataAnnotations;
using WebApplicationManage.Data;

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

        public Role? Role { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
