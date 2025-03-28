using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Interfaces;

namespace ECommerce.Application.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository; 
        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategoriesByCategoryId(int id)
        {
            return await _subCategoryRepository.GetSubCategoriesByCategoryId(id);
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategories()
        {
            return await _subCategoryRepository.GetSubCategories();
        }  
        
        public async Task<SubCategory> SetSubCategory(SubCategory subCategory)
        {
            return await _subCategoryRepository.CreateSubCategory(subCategory);
        }
        public async Task<bool> UpdateSubCategory(SubCategory subCategory)
        {
            return await _subCategoryRepository.UpdateSubCategory(subCategory);
        }

        public async Task<bool> DeleteSubCategory(int id)
        {
            return await _subCategoryRepository.DeleteSubCategory(id);
        }   
    }
}
