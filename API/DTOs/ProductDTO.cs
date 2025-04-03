namespace ECommerce.API.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public decimal AvgRate { get; set; }
        public string Brand { get; set; }
        public decimal DiscountAmount { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsDeleted { get; set; }
        public string color { get; set; }
        public decimal finalPrice { get; set; }

        public string Category { get; set; }


    }
}
