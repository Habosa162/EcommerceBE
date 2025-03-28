using ECommerce.API.DTOs;
using ECommerce.Domain.Models;

namespace ECommerce.Application.Interfaces
{
    public interface IProductService
    {
        public  Task<IEnumerable<ProductDTO>> GetAllProducts();

        public Task<ProductDTO> GetProductById(int id);

        public Task<IEnumerable<ProductDTO>> GetProductsBySubCategoryId(int subCateID);

        public Task<Product> CrteateProduct(ProductDTO product, IFormFile imgurl);
        public Task<bool> UpdateProduct(int id, ProductDTO product);
        public Task<bool> DeleteProdcut(int id);

    }
}
