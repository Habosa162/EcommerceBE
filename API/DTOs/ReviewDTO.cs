namespace ECommerce.API.DTOs
{
    public class ReviewDTO
    {
        public int ProductId { get; set; } 
        public string Comment { get; set; }
        public int Rating { get; set; } 
    }
}
