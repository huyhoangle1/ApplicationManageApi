using System.ComponentModel.DataAnnotations;

namespace WebApplicationManage.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? OrderCode { get; set; }

        [Required]
        public int Customerid { get; set; }
        public DateTime Orderdate { get; set; }

        public string? FullName { get; set; }

        public string? Phone { get; set; }

        public int? Money { get; set; }
        public int? Price_ship { get; set; }
        public int? Coupon { get; set; }
        public string? Address { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public Customer Customer { get; set; }

        public int? Status { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }

    }
}

