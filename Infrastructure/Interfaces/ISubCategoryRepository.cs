using ECommerce.Domain.Models;

namespace ECommerce.Infrastructure.Interfaces
{
    public interface ISubCategoryRepository
    {
 

        public Task<IEnumerable<SubCategory>> GetSubCategoriesByCategoryId(int catId);
        public Task<IEnumerable<SubCategory>> GetSubCategories();
        Task<SubCategory> GetSubCategoryById(int id);
        public Task<SubCategory> SetSubCategory(SubCategory SubCategory);
        public Task<bool> UpdateSubCategory(SubCategory SubCategory);
        public Task<bool> DeleteSubCategory(int id);

    }
}
