using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories
{
    public class SubCategoryRepository : ISubCategoryRepository

    {
        private readonly ApplicationDbContext _context;

        public SubCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<bool> DeleteSubCategory(int id)
        {
            var DelSubCategory = await _context.SubCategories.FindAsync(id);
            if (DelSubCategory != null) { 
                 _context.SubCategories.Remove(DelSubCategory);
                return await _context.SaveChangesAsync() > 0 ;
            }
            return false;
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategories()
        {
            return await _context.SubCategories.Include(sc=>sc.Category).ToListAsync();
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategoriesByCategoryId(int id)
        {
            return await _context.SubCategories.Where(sc=>sc.CategoryId==id).Include(sc=>sc.Category).ToListAsync();
        }

        public async Task<bool> SetSubCategory(SubCategory SubCategory)
        {
            await _context.SubCategories.AddAsync(SubCategory);
            return await _context.SaveChangesAsync() > 0    ;
        }

        public async Task<bool> UpdateSubCategory(SubCategory SubCategory)
        {
            _context.Update(SubCategory);
            return await _context.SaveChangesAsync() > 0    ;
        }
    }
}
