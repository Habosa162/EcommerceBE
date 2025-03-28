using ECommerce.API.DTOs;
using ECommerce.Domain.Models;

namespace ECommerce.Application.Interfaces
{
    public interface ISubCategoryService
    {
        public Task<IEnumerable<SubCategory>> GetSubCategoriesByCategoryId(int id);
        public Task<IEnumerable<SubCategory>> GetSubCategories();
        public Task<SubCategory> SetSubCategory(SubCategoryDTO subCategory);
        public Task<bool> UpdateSubCategory(int id, SubCategoryDTO subCategory);
        public Task<bool> DeleteSubCategory(int id);
    }
}
