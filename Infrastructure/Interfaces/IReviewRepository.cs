using ECommerce.Domain.Models;

namespace ECommerce.Infrastructure.Interfaces
{
    public interface IReviewRepository
    {
        public Task<Review> GetReview(int id); 
        public Task<IEnumerable<Review>> GetProductReviews(int Productid);   
        public Task<Review> SetReview(Review review);   
        public Task<bool> DeleteReview(int id);   
        public Task<bool> UpdateReview(Review review);    

    }
}
