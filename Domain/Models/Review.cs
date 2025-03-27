using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EComm.Domain.Models
{
    public class Review
    {

        [Key]
        public int Id { get; set; }

        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required, ForeignKey("Customer")]
        public string CustomerId { get; set; }

        [Required, Range(0, 5)]
        public decimal Rating { get; set; }


        public string? Comment { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Product? Product { get; set; }
        public AppUser? Customer { get; set; }
    }
}
