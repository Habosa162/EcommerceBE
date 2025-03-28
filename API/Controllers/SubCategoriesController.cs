using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerce.Domain.Models;
using ECommerce.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using ECommerce.Application.Services;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoriesController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        // GET: api/SubCategories
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetSubCategories()
        {
            var subCategories = await _subCategoryService.GetSubCategories();   
            return Ok(subCategories);
        }

        // GET: api/SubCategories/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubCategory(int id)
        {
            var subCategory = await _subCategoryService.GetSubCategoriesByCategoryId(id);

            if (subCategory == null)
            {
                return NotFound();
            }

            return Ok(subCategory);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubCategory(int id, SubCategory subCategory)
        {
            if (id != subCategory.Id)
            {
                return BadRequest();
            }

            //_context.Entry(subCategory).State = EntityState.Modified;
              var res = await _subCategoryService.UpdateSubCategory(subCategory);
            if (res)
            {
                return Ok(new {success= true , messsage = "SubCategory Updated Successfully"});
            }
            else
            {
                return BadRequest(new {success=false , message= "SuCatgeory Updated Failed"});    
            }

        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult<SubCategory>> PostSubCategory(SubCategory subCategory)
        {
            var res = await _subCategoryService.SetSubCategory(subCategory);
            if (res)
            {
                return Ok(new { success = true, messsage = "SubCategory Created Successfully" });
            }
            else
            {
                return BadRequest(new { success = false, message = "SuCatgeory Creation Failed" });
            }   
            //return CreatedAtAction("GetSubCategory", new { id = subCategory.Id }, subCategory);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            var res = await _subCategoryService.DeleteSubCategory(id);
            if (res)
            {
                return Ok(new {success = true , message = "SubCatgeory Deleted Successfully"});
            }
            else
            {
                return BadRequest(new { success = false, message = "SubCatgeory Deletion Failed" }); 
            }
        }

    }
}
