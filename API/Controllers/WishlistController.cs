
using ECommerce.Application.Interfaces;
using ECommerce.Application.Services;
using ECommerce.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EComm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IWishListService _wishlistService;
        public WishlistController(IWishListService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WishList>>> GetWishlist()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var wishlist = await _wishlistService.GetWishlistByUser(userId);
            return Ok(wishlist);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddToWishlist(int productId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var success = await _wishlistService.AddToWishlist(userId, productId);
            if (!success)
            {
                return BadRequest("Product already in wish list");
            }
            return Ok("Product added to wish list");
        }

        [Authorize]
        [HttpDelete("{productId}")]
        public async Task<ActionResult> RemoveFromWishlist(int productId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

           var success= await _wishlistService.RemoveFromWishlist(userId,productId);
            if (!success)
            {
                return BadRequest("Product not found in wish list");
            }
            return Ok("Product removed from wish list");
        }


    }
}
