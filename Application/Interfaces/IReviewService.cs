using ECommerce.API.DTOs;
using ECommerce.Domain.Models;

namespace ECommerce.Application.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetReviewsForProduct(int productId);
        Task<Review?> GetReviewById(int id);
        Task<Review> CreateReview(ReviewDTO reviewDto);
        Task<bool> UpdateReview(int id, ReviewDTO reviewDto);
        Task<bool> DeleteReview(int id);
    }
}
