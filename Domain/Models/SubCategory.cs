using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EComm.Domain.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, ForeignKey("Category")]
        public int CategoryId { get; set; }


        [Required]
        public string ImgUrl { get; set; } = string.Empty;

        public Category? Category { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
