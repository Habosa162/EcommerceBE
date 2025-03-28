using ECommerce.API.DTOs;
using ECommerce.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController( IProductService productService )
        {
            _productService = productService;

        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("subcategory/{subCategoryId}")]
        public async Task<IActionResult> GetProductsBySubCategory(int subCategoryId)
        {
            return Ok(await _productService.GetProductsBySubCategoryId(subCategoryId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] ProductDTO productDto, [FromForm] IFormFile productImage)
        {
            var product = await _productService.CrteateProduct(productDto, productImage);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] ProductDTO productDto)
        {
            var updated = await _productService.UpdateProduct(id, productDto);
            if (!updated) return BadRequest("Update failed");
            return Ok("product Updated") ;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _productService.DeleteProdcut(id);
            if (!deleted) return BadRequest("Delete failed");
            return Ok("Product Deleted");
        }
    }
}
