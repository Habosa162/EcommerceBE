using Azure.Core;
using ECommerce.API.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly IShippingServices _shippingService;
        public ShippingController(IShippingServices shippingServices )
        {
            _shippingService = shippingServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShipings()
        {
            var shipping = await _shippingService.GetAllShippings();
            if (shipping.Any())
            {
                return Ok(shipping);
            }
            return NotFound(new { success = false, message = "No shipping found" });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShippingById(int id)
        {
            var shipping = await _shippingService.GetShippingById(id);
            if (shipping != null)
            {
                return Ok(shipping);
            }
            return NotFound(new { success = false, message = "Shipping not found" });
        }
        [HttpGet("GetShippingByOrderId/{orderId}")]
        public async Task<IActionResult> GetShippingByOrderId(int orderId)
        {
            var shipping = await _shippingService.GetShippingByOrderId(orderId);
            if (shipping != null)
            {
                return Ok(shipping);
            }
            return NotFound(new { success = false, message = "Shipping not found" });
        }
        [HttpPost]
        public async Task<IActionResult> CreateShipping([FromBody] ShippingDTO shipping)
        {
            var newShipping = await _shippingService.CreateShipping(shipping);

            if (newShipping == null)
            {

                return BadRequest(new { success = false, message = "Failed to create shipping" });
            }
            else
            {
                return Ok(new { success = true, message = "Shipping created successfully" });
            }
        }
        [HttpPut("{id}/Status")]
        public async Task<IActionResult> UpdateShippingStatus(int id, [FromBody] ShippingStatus status)
        {
            if (!Enum.IsDefined(typeof(ShippingStatus), status))
            {
                return BadRequest(new { success = false, message = "Invalid shipping status." });
            }
            var updatedShipping = await _shippingService.UpdateShippingStatus(id, status);
            if (!updatedShipping)
            {
                return BadRequest(new { success = false, message = "Failed to update shipping" });
            }
            else
            {
                return Ok(new { success = true, message = "Shipping updated successfully" });
            }
        }
    }
}
