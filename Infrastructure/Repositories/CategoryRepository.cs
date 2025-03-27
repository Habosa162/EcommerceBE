using ECommerce.API.DTOs;
using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories
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

        public async Task SetCategory(CategoryDTO category)
        {
            var newCate = new Category
            {
                Name = category.Name,
                ImgUrl= category.ImgUrl
            };
            await _context.Categories.AddAsync(newCate);
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateCategory(int id,CategoryDTO category)
        {
            var editCate = await GetCategory(id);
            if (editCate != null) 
            {
                editCate.Name = category.Name;
                editCate.ImgUrl = category.ImgUrl;
            }
            await _context.SaveChangesAsync();
        }
    }
}
