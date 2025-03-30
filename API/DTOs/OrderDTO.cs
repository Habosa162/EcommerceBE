using ECommerce.Domain.Enums;

namespace ECommerce.API.DTOs
{
    public class OrderDTO
    {
        public int id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public PaymentStatus PaymentStatus { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new();
        public ShippingStatus? ShippingStatus { get; set; }
        public DateTime? DelivaryDate { get; set; }

    }
}
