using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationManage.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public int CatId { get; set; }

        public string Name { get; set; }

        public byte[] Avatar { get; set; }

        [MaxLength]
        public byte[] Image { get; set; }

        public string SortDesc { get; set; }

        public string Detail { get; set; }

        public int Producer { get; set; }

        public int Number { get; set; }

        public int Number_buy { get; set; }

        public int Price { get; set; }

        public int Sale { get; set;}

        public int Price_sale { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public Producer producer { get; set; }

        public Category Category { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Product()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
