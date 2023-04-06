using System.ComponentModel.DataAnnotations;

namespace WebApplicationManage.models.Order
{
    public class OrderDto
    {
        public int? OrderCode { get; set; }
        public int Customerid { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }

        public int? Money { get; set; }
        public int? Price_ship { get; set; }
        public int? Coupon { get; set; }
        public string? Address { get; set; }
        public int? Status { get; set; }

        public List<OrderProductDto> Products { get; set; }

    }
}
