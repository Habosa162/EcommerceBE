using ECommerce.API.DTOs;
using ECommerce.Domain.Models;

namespace ECommerce.Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAllCategories();
        public Task<Category?> GetCategory(int id);
        public Task SetCategory(CategoryDTO category);
        public Task UpdateCategory(int id, CategoryDTO category);
        public Task DeleteCategory(int id);
    }
}
