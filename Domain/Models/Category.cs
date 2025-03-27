using System.ComponentModel.DataAnnotations;

namespace EComm.Domain.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string ImgUrl { get; set; } = string.Empty;

        public ICollection<SubCategory>? SubCategories { get; set; }
    }
}
