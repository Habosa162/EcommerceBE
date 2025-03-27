using EComm.Domain.Models;
using EComm.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EComm.Infrastructure.Repositories
{
    public class SubCategoryRepository : ISubCategoryRepository

    {
        private readonly ApplicationDbContext _context;

        public SubCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task DeleteSubCategory(int id)
        {
            var DelSubCategory = await _context.SubCategories.FindAsync(id);
            if (DelSubCategory != null) { 
                 _context.SubCategories.Remove(DelSubCategory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategories()
        {
            return await _context.SubCategories.Include(sc=>sc.Category).ToListAsync();
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategoriesByCategoryId(int id)
        {
            return await _context.SubCategories.Where(sc=>sc.CategoryId==id).Include(sc=>sc.Category).ToListAsync();
        }

        public async Task SetSubCategory(SubCategory SubCategory)
        {
           
           await _context.SubCategories.AddAsync(SubCategory);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateSubCategory(SubCategory SubCategory)
        {
            _context.Update(SubCategory);
            await _context.SaveChangesAsync();
        }
    }
}
