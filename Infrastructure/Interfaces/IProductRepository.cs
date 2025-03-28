using ECommerce.Domain.Models;

namespace ECommerce.Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducts();
        public Task<IEnumerable<Product>> GetProductsBySubCategoryId(int id);
        //public Task<IEnumerable<Product>> GetProductsByCategoryId(int id);
        public Task<Product?> GetProductById(int id);
        public Task<Product> SetProduct(Product product);
        public Task<bool> UpdateProduct(Product product);
        public Task<bool> DeleteProduct(int id);
    }
}
