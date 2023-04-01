using System.ComponentModel.DataAnnotations;

namespace WebApplicationManage.Data
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? FullName { get; set; }

        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }

        public string? Address { get; set; }

        public int? Phone { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
