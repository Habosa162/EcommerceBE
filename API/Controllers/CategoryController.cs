using ECommerce.API.DTOs;
using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
           var categories = await _categoryRepository.GetAllCategories();
            return Ok(categories);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategory(id);
            return Ok(new {success = true , message = "Category Deleted Successfully"});
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(CategoryDTO category)
        {
             await _categoryRepository.SetCategory(category);
            return Ok(new {success=true , message = "Category Created Successfully"});
        }


        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> UpdateCategory(int id,CategoryDTO catgory)
        {
          
           await _categoryRepository.UpdateCategory(id, catgory);
            
            return Ok(new {succss = true , messeage = $"category:{catgory.Name} is updated successfully" });
        }
    }
}
