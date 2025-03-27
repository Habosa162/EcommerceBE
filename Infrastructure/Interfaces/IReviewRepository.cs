using ECommerce.Domain.Models;

namespace ECommerce.Infrastructure.Interfaces
{
    public interface IReviewRepository
    {
        public Task<Review?> GetReview(int id); 
        public Task<IEnumerable<Review>> GetProductReviews(int Productid);   
        public Task SetReview(Review review);   
        public Task DeleteReview(int id);   
        public Task UpdateReview(Review review);    

    }
}
