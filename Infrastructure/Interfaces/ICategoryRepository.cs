using ECommerce.API.DTOs;
using ECommerce.Domain.Models;

namespace ECommerce.Infrastructure.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<Category?> GetCategory(int id);
        public Task SetCategory(CategoryDTO category); 
        public Task UpdateCategory(int id,CategoryDTO category);  
        public Task DeleteCategory(int id);
        public Task<IEnumerable<Category>> GetAllCategories();
    }
}
