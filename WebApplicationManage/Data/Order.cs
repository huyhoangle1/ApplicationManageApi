using System.ComponentModel.DataAnnotations;

namespace WebApplicationManage.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public int? OrderCode { get; set; }

        [Required]
        public int Customerid { get; set; }
        [Required]
        public DateTime Orderdate { get; set; }

        public string? Fullname { get; set; }

        public int? Phone { get; set; }

        public int? Money { get; set; }
        public int? Price_ship { get; set; }
        public int? Coupon { get; set; }
        public string? Address { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public Customer Customer { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }

    }
}

