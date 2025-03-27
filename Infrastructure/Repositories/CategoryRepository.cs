using EComm.Domain.Models;
using EComm.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EComm.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task DeleteCategory(int id)
        {
            var category = await GetCategory(id);
            if (category != null) {
                _context.Remove(category);
                await _context.SaveChangesAsync(); 
            }

        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
           return await _context.Categories.Include(c=>c.SubCategories).ToListAsync();
        }

        public async Task<Category?> GetCategory(int id)
        {
            return await _context.Categories.Include(c=>c.SubCategories).FirstOrDefaultAsync(c => c.Id == id); 
        }

        public async Task SetCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateCategory(Category category)
        {
            _context.Categories.Update(category); 
            await _context.SaveChangesAsync();
        }
    }
}
