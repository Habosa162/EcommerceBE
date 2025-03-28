using ECommerce.Domain.Models;

namespace ECommerce.Application.Interfaces
{
    public interface ISubCategoryService
    {
        public Task<IEnumerable<SubCategory>> GetSubCategoriesByCategoryId(int id);
        public Task<IEnumerable<SubCategory>> GetSubCategories();
        public Task<bool> SetSubCategory(SubCategory subCategory);
        public Task<bool> UpdateSubCategory(SubCategory subCategory);
        public Task<bool> DeleteSubCategory(int id);
    }
}
