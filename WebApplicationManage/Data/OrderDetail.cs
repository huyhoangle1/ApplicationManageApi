using System.ComponentModel.DataAnnotations;

namespace WebApplicationManage.Data
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        [MaxLength(100)]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public int Count { get; set; }

        [Required]
        [MaxLength(100)]
        public float Price { get; set; }

        [Required]
        public bool Status { get; set; }

        //relationship
        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}
