using ECommerce.Domain.Enums;

namespace ECommerce.API.DTOs
{
    public class OrderDTO
    {
        public decimal TotalAmount { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public PaymentStatus PaymentStatus { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new();

    }
}
