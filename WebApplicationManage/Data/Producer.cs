﻿using System.ComponentModel.DataAnnotations;

namespace WebApplicationManage.Data
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Code { get; set; }

        [Required]
        public string Keyword { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Modified { get; set; }

        [Required]
        public int Trash { get; set; }

        [Required]
        public int Status { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
