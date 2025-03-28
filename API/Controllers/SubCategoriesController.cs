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
using ECommerce.API.DTOs;

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

        //[Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubCategory(int id, SubCategoryDTO subCategoryDto)
        {

            var success = await _subCategoryService.UpdateSubCategory(id, subCategoryDto);

            if (!success)
                return BadRequest(new { success = false, message = "SuCatgeory Updated Failed" });
            else
                return Ok(new { success = true, messsage = "SubCategory Updated Successfully" });

      

        }


        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<SubCategory>> PostSubCategory(SubCategoryDTO subCategory)
        {
            var res = await _subCategoryService.SetSubCategory(subCategory);
            if (res != null)
            {
                return Ok(new { success = true, messsage = "SubCategory Created Successfully" });
            }
            else
            {
                return BadRequest(new { success = false, message = "SuCatgeory Creation Failed" });
            }   
        }

        //[Authorize]
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
