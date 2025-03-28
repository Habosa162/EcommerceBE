using ECommerce.API.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Interfaces;

namespace ECommerce.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;   
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;   
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _categoryRepository.GetAllCategories();
        }

        public async Task<Category?> GetCategory(int id)
        {
            return await _categoryRepository.GetCategory(id);
        }

        public async Task SetCategory(CategoryDTO category)
        {
            await _categoryRepository.SetCategory(category);
        }

        public async Task UpdateCategory(int id, CategoryDTO category)
        {
            await _categoryRepository.UpdateCategory(id, category);
        }

        public async Task DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategory(id);
        }   
    }
}
