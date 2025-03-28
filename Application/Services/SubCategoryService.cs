using ECommerce.API.DTOs;
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
        
        public async Task<SubCategory> SetSubCategory(SubCategoryDTO subCategoryDto)
        {
            var subCategory = new SubCategory
            {
                Name = subCategoryDto.Name,
                CategoryId = subCategoryDto.CategoryId,
                ImgUrl = subCategoryDto.ImgUrl
            };  
            return await _subCategoryRepository.CreateSubCategory(subCategory);
        }
        public async Task<bool> UpdateSubCategory(int id, SubCategoryDTO subCategoryDto)
        {
            var subCategory = await _subCategoryRepository.GetSubCategoryById(id);
            if (subCategory == null)
            {
                return false;
            }
            subCategory.CategoryId = subCategoryDto.CategoryId;
            subCategory.Name = subCategoryDto.Name;
            subCategory.ImgUrl = subCategoryDto.ImgUrl;
            return await _subCategoryRepository.UpdateSubCategory(subCategory);
        }

        public async Task<bool> DeleteSubCategory(int id)
        {
            return await _subCategoryRepository.DeleteSubCategory(id);
        }   
    }
}
