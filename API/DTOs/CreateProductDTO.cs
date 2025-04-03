namespace ECommerce.API.DTOs
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int SubCategoryId { get; set; }
        public int Stock { get; set; }
        public decimal AvgRate { get; set; }
        public string Brand { get; set; }
        public decimal DiscountAmount { get; set; }
        public string color { get; set; }
    }
}
