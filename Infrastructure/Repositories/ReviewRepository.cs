using EComm.Domain.Models;
using EComm.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EComm.Infrastructure.Repositories
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
        public async Task DeleteReview(int id)
        {
            var review = await GetReview(id);
            if (review != null) { 
                _context.Reviews.Remove(review);    
                await _context.SaveChangesAsync();  
            }   
        }

        public async Task<IEnumerable<Review>> GetProductReviews(int Productid)
        {
            return await _context.Reviews
                .Where(r => r.ProductId == Productid)
                .Include(r => r.Customer)
                .Include(r => r.Product)
                .ToListAsync(); 
        }

        public async Task SetReview(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateReview(Review review)
        {
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync(); 
        }
    }
}
