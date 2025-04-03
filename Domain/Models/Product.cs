using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Domain.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        public string? color { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [MaxLength(1000)]
        public string? ImgUrl { get; set; }

        [Required]
        public int Stock { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AvgRate { get; set; } = 0.0m;

        [ForeignKey("SubCategory")]
        public int? SubCategoryId { get; set; }

        [MaxLength(100)]
        public string? Brand { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountAmount { get; set; } = 0.0m;

        [NotMapped]
        public decimal FinalPrice => Price - DiscountAmount < 0 ? 0 : Price - DiscountAmount;

        public bool IsAccepted { get; set; } = true;
        public bool IsDeleted { get; set; } = false; 
        // Relationships
        public SubCategory? SubCategory { get; set; }

    }
}
