using EComm.Domain.Models;

namespace EComm.Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducts();
        public Task<IEnumerable<Product>> GetProductsBySubCategoryId(int id);
        //public Task<IEnumerable<Product>> GetProductsByCategoryId(int id);
        public Task<Product?> GetProduct(int id);
        public Task SetProduct(Product product);
        public Task UpdateProduct(Product product);
        public Task DeleteProduct(int id);
    }
}
