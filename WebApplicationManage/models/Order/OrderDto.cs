using System.ComponentModel.DataAnnotations;

namespace WebApplicationManage.models.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int? OrderCode { get; set; }
        public int Customerid { get; set; }
        public DateTime Orderdate { get; set; }

        public string? Fullname { get; set; }

        public int? Phone { get; set; }

        public int? Money { get; set; }
        public int? Price_ship { get; set; }
        public int? Coupon { get; set; }
        public string? Address { get; set; }

        public DateTime Created { get; set; }

    }
}
