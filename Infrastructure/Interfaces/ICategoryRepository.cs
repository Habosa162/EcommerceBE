using ECommerce.Domain.Models;

namespace ECommerce.Infrastructure.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<Category?> GetCategory(int id);
        public Task SetCategory(Category category); 
        public Task UpdateCategory(Category category);  
        public Task DeleteCategory(int id);
        public Task<IEnumerable<Category>> GetAllCategories();
    }
}
