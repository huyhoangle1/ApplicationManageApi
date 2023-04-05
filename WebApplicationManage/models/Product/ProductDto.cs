using System.ComponentModel.DataAnnotations;
using WebApplicationManage.Data;

namespace WebApplicationManage.models.Product
{

        public class ProductDto
        {
            public int? CatId { get; set; }
            [Required]

            public string? Name { get; set; }

            public string? Avatar { get; set; }

            [MaxLength]
            public string? Image { get; set; }

            public string? SortDesc { get; set; }

            public string? Detail { get; set; }

            public int? Producer { get; set; }

            public int? Number { get; set; }

            public int? Number_buy { get; set; }

            public int? Price { get; set; }

            public int? Sale { get; set; }

            public int? Price_sale { get; set; }

            public DateTime? Created { get; set; }

            public DateTime? Modified { get; set; }
        }
}
