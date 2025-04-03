using ECommerce.API.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Interfaces;

namespace ECommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IAwsService _awsService;
        private readonly IConfiguration _configuration;
        public ProductService(IProductRepository productRepository, IAwsService awsService, IConfiguration configuration)
        {
            _productRepository = productRepository;
            _awsService = awsService;
            _configuration = configuration;
        }
        public async Task<Product> CrteateProduct(CreateProductDTO productDto, IFormFile file)
        {
            var imageUrl = "";

            if (productDto.Price < 0 || productDto.DiscountAmount < 0)
            {
                throw new ArgumentException("Price and Discount Amount cannot be negative.");
            }

            if (productDto.Price > 9999999999999999.99m) 
            {
                throw new ArgumentException("Price exceeds the maximum allowed value.");
            }

            if (file != null)
            {
                imageUrl = await _awsService.UploadFileAsync(file, "products");
            }

            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                SubCategoryId = productDto.SubCategoryId,
                ImgUrl = imageUrl,
                Stock = productDto.Stock,
                AvgRate = productDto.AvgRate,
                Brand = productDto.Brand,
                DiscountAmount = productDto.DiscountAmount,
                color = productDto.color
            };

            return await _productRepository.SetProduct(product);
        }


        public Task<bool> DeleteProdcut(int id)
        {
        
            return _productRepository.DeleteProduct(id);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var products = await _productRepository.GetProducts();
            return  products.Select(product => new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                SubCategoryId = (int)product.SubCategoryId,
                SubCategoryName = product.SubCategory?.Name,
                ImageUrl = product.ImgUrl,
                Stock = product.Stock,
                AvgRate = product.AvgRate,
                Brand = product.Brand,
                DiscountAmount = product.DiscountAmount,
                IsAccepted = product.IsAccepted,
                IsDeleted = product.IsDeleted,
                color = product.color,
                finalPrice = product.FinalPrice

            }).ToList();
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var product = await _productRepository.GetProductById(id);
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                SubCategoryId = (int)product.SubCategoryId,
                SubCategoryName = product.SubCategory?.Name,
                ImageUrl = product.ImgUrl,
                Stock = product.Stock,
                AvgRate = product.AvgRate,
                Brand = product.Brand,
                DiscountAmount = product.DiscountAmount,
                IsAccepted = product.IsAccepted,
                IsDeleted = product.IsDeleted,
                color = product.color
            };
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsBySubCategoryId(int subCateID)
        {
            var products = await _productRepository.GetProductsBySubCategoryId(subCateID);
            return products.Select(product => new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                SubCategoryId = (int)product.SubCategoryId,
                SubCategoryName = product.SubCategory?.Name,
                ImageUrl = product.ImgUrl,
                Stock = product.Stock,
                AvgRate = product.AvgRate,
                Brand = product.Brand,
                DiscountAmount = product.DiscountAmount,
                IsAccepted = product.IsAccepted,
                IsDeleted = product.IsDeleted,
                color = product.color
            }).ToList();

        }

        public async Task<IEnumerable<ProductDTO>> GetTopSold( int count)
        {
            var products = await _productRepository.GetMostSellingProducts(count);

            var productDtos = products.Select(product => new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                SubCategoryId = (int)product.SubCategoryId,
                SubCategoryName = product.SubCategory?.Name,
                ImageUrl = product.ImgUrl,
                Stock = product.Stock,
                AvgRate = product.AvgRate,
                Brand = product.Brand,
                DiscountAmount = product.DiscountAmount,
                IsAccepted = product.IsAccepted,
                IsDeleted = product.IsDeleted,
                color = product.color,
                finalPrice = product.FinalPrice
            }).ToList();
            return  productDtos;

        }

        public async Task<bool> UpdateProduct(int id, ProductDTO productDto)
        {
            //update img logic?
            var product = await _productRepository.GetProductById(id);
            if (product == null) return false;
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.SubCategoryId = productDto.SubCategoryId;
            product.Stock = productDto.Stock;
            product.AvgRate = productDto.AvgRate;
            product.Brand = productDto.Brand;
            product.DiscountAmount = productDto.DiscountAmount;
            product.IsAccepted = productDto.IsAccepted;
            product.IsDeleted = productDto.IsDeleted;
            product.color = productDto.color;
            return await _productRepository.UpdateProduct(product);
        }
    }
}
