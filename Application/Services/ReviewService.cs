using ECommerce.API.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Interfaces;

namespace ECommerce.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<bool> CreateReview(string userId, ReviewDTO reviewDto)
        {
            
            var review = new Review
          {
              CustomerId = userId,
              ProductId = reviewDto.ProductId,
              Comment = reviewDto.Comment,
              Rating = reviewDto.Rating,
              CreatedAt = DateTime.UtcNow

          };
            return await _reviewRepository.SetReview(review);
        }

        public async Task<bool> DeleteReview(int id)
        {
            return await _reviewRepository.DeleteReview(id);

        }

        public async Task<Review> GetReviewById(int id)
        {
            return await _reviewRepository.GetReview(id);
        }

        public async Task<IEnumerable<Review>> GetReviewsForProduct(int productId)
        {
            return await _reviewRepository.GetProductReviews(productId);
        }

        public async Task<bool> UpdateReview(int id, ReviewDTO reviewDto, string userId)
        {
           var updatedReview = await _reviewRepository.GetReview(id);
            if (updatedReview == null|| updatedReview.CustomerId != userId) return false;

            updatedReview.Comment = reviewDto.Comment;
            updatedReview.Rating = reviewDto.Rating;

            return await _reviewRepository.UpdateReview(updatedReview);

        }


    }
}
