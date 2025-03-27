using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EComm.Domain.Enums;

namespace EComm.Domain.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Required, Column(TypeName = "decimal(18,2)")]
        
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal TotalAmount { get; set; }

        [Required, ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public AppUser? Customer { get; set; }


        [Required, MaxLength(20)]
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }


}
