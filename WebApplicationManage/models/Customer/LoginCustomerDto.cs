using System.ComponentModel.DataAnnotations;

namespace WebApplicationManage.models.Customer
{
    public class LoginCustomerDto
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
