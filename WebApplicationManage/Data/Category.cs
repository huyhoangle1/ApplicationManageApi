using System.ComponentModel.DataAnnotations;

namespace WebApplicationManage.Data
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        public int ParentId { get; set; }

        public DateTime Created { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
