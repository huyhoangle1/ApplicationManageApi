using System.ComponentModel.DataAnnotations;

namespace WebApplicationManage.models.Category
{
    public class CategoryDto
    {

            public int Id { get; set; }
            [Required]
            public string Name { get; set; }

            [Required]
            public string Link { get; set; }

            [Required]
            public int Level { get; set; }

            [Required]
            public int ParentId { get; set; }


    }
}
