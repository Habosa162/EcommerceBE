using ECommerce.API.DTOs;
using ECommerce.Domain.Models;

namespace ECommerce.Application.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetReviewsForProduct(int productId);
        Task<Review?> GetReviewById(int id);
        Task<bool> CreateReview(string userId , ReviewDTO reviewDto);
        Task<bool> UpdateReview(int id, ReviewDTO reviewDto, string userId);
        Task<bool> DeleteReview(int id);
    }
}
