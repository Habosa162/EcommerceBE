namespace ECommerce.API.DTOs
{
    public class OrderItemDto
    {
        public string Name { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public string productImg { get; set; }
    }
}
