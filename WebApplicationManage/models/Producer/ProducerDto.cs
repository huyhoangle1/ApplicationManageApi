using System.ComponentModel.DataAnnotations;

namespace WebApplicationManage.models.Producer
{
    public class ProducerDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Code { get; set; }

        [Required]
        public string Keyword { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public int Trash { get; set; } 

        public int Status { get; set; } 

    }
}
