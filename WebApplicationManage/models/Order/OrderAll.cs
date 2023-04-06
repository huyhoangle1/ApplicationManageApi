using System.ComponentModel.DataAnnotations;
using WebApplicationManage.Data;

namespace WebApplicationManage.models.Order
{
    public class OrderAll
    {

        public string? OrderCode { get; set; }

        public int Customerid { get; set; }
        public DateTime Orderdate { get; set; }

        public string? FullName { get; set; }

        public string? Phone { get; set; }

        public int? Money { get; set; }
        public int? Price_ship { get; set; }
        public int? Coupon { get; set; }
        public string? Address { get; set; }

        public DateTime Created { get; set; }

        public int? Status { get; set; }
  
        public List<OrderProductDto> Products { get; set; }

    }
}
