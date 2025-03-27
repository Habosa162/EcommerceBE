using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EComm.Domain.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required, ForeignKey("Order")]
        public int OrderId { get; set; }

        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Required]
        public int Qty { get; set; }

        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}
