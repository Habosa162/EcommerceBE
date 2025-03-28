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



        public async Task<SubCategory> GetSubCategoryById(int id)
        {
            return await _context.SubCategories.Include(sc => sc.Category).FirstOrDefaultAsync(sc => sc.Id == id);
        }

  


        public async Task<bool> DeleteSubCategory(int id)
        {
            var DelSubCategory = await GetSubCategoryById(id);
            if (DelSubCategory != null) { 
                 _context.SubCategories.Remove(DelSubCategory);

                return await _context.SaveChangesAsync()>0;

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


   



        public async Task<SubCategory> CreateSubCategory(SubCategory SubCategory)
        {
            await _context.SubCategories.AddAsync(SubCategory);
            await _context.SaveChangesAsync();
            return SubCategory;

        }

        public async Task<bool> UpdateSubCategory(SubCategory SubCategory)
        {
            _context.SubCategories.Update(SubCategory);

            return await _context.SaveChangesAsync() > 0;
        }

  

   
    }
}
