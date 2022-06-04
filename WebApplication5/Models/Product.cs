using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]

        public double Price { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Greater then 0")]
        public int CategoryId { get; set; }
        [Required]
        public string Image { get; set; }
        public virtual Category Category { get; set; }


    }
}
