using ECommerce.API.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [AllowAnonymous]
        [HttpGet("productReviews/{productId}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsForProduct(int productId)
        {
            var reviews = await _reviewService.GetReviewsForProduct(productId);
            return Ok(reviews);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _reviewService.GetReviewById(id);
            if (review == null)
                return NotFound();

            return Ok(review);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Review>> CreateReview(ReviewDTO reviewDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var res = await _reviewService.CreateReview(userId, reviewDto);
            if (res)
            {
                return Ok(new {success = true , message="Review Created Successfully"});
            }
            else
            {
                return BadRequest(new { success = false, message = "Review Creation Failed" });
            }
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] ReviewDTO reviewDto)
        {
            
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            
            var success = await _reviewService.UpdateReview(id, reviewDto, userId);
            if (!success)
                return BadRequest(new {success = false , message ="Review Update Failed"}); 

            return Ok(new {success=true, message = "Review Updated Successfully" });
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
           
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            

            
            var review = await _reviewService.GetReviewById(id);
            if (review == null || review.CustomerId != userId)
                return Unauthorized(); 

            var success = await _reviewService.DeleteReview(id);
            if (!success)
                return BadRequest(new {success=false , message= "Review Delete Failed" });

            return Ok(new {success=true , message = "Review Deleted Successfully" });
        }
    }
}
