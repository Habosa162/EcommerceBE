using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Review?> GetReview(int id)
        {
            return await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id); 
        }
        public async Task<bool> DeleteReview(int id)
        {
            var review = await GetReview(id);
            if (review != null) { 
                _context.Reviews.Remove(review);    
               return await _context.SaveChangesAsync() > 0;
                
            }   
            return false;
        }

        public async Task<IEnumerable<Review>> GetProductReviews(int Productid)
        {
            return await _context.Reviews
                .Where(r => r.ProductId == Productid)
                .Include(r => r.Customer)
                .Include(r => r.Product)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync(); 
        }

        public async Task<bool> SetReview(Review review)
        {
            await _context.Reviews.AddAsync(review);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateReview(Review review)
        {
            var existingReview = await GetReview(review.Id);
            if (existingReview == null) return false;
            _context.Reviews.Update(review);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
