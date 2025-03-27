using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EComm.Domain.Enums;

namespace EComm.Domain.Models
{
    public class Shipping
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeliveryDate { get; set; }

        [Required, MaxLength(20)]
        public ShippingStatus ShippingStatus { get; set; } = ShippingStatus.pending;


        [Required, ForeignKey("Order")]
        public int OrderId { get; set; }

        [Required, ForeignKey("Customer")]
        public string CustomerId { get; set; }

        public Order? Order { get; set; }
        public AppUser? Customer { get; set; }

        [MaxLength(100)]
        public string Country { get; set; } = string.Empty;

        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Gov { get; set; } = string.Empty;

        [MaxLength(255)]
        public string Street { get; set; } = string.Empty;
    }
}
