using ECommerce.API.DTOs;
using ECommerce.Domain.Models;

namespace ECommerce.Application.Interfaces
{
    public interface IProductService
    {
        public  Task<IEnumerable<ProductDTO>> GetAllProducts();
        public  Task<IEnumerable<ProductDTO>> GetTopSold(int count);

        public Task<ProductDTO> GetProductById(int id);

        public Task<IEnumerable<ProductDTO>> GetProductsBySubCategoryId(int subCateID);

        public Task<Product> CrteateProduct(CreateProductDTO product, IFormFile imgurl);
        public Task<bool> UpdateProduct(int id, ProductDTO product);
        public Task<bool> DeleteProdcut(int id);

        public Task<IEnumerable<ProductDTO>> SearchProductsByName(string name);

    }
}
