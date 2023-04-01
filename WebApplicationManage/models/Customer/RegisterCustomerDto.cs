using System.ComponentModel.DataAnnotations;

namespace WebApplicationManage.models.Customer
{
    public class RegisterCustomerDto
    {
        [Required]
        public string? FullName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
