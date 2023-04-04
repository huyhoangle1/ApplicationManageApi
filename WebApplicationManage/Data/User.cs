using System.ComponentModel.DataAnnotations;

namespace WebApplicationManage.Data
{
    public enum Role
    {
        admin = 0, personnel = 1
    }
    public class User
    {
        public User()
        {
            Tokens = new HashSet<Token>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }

        public Role? Role { get; set; }

        public string? Image { get; set; }

        public string? Address { get; set; }

        public DateTime? Created { get; set; }

        public ICollection<Token> Tokens { get; set; }

        public ICollection<Producer> Producers { get; set; }

    }
}
