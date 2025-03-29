using ECommerce.API.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Services;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("GetUserOrders/{customerId}")]
        public async Task<IActionResult> GetUserOrders(string customerId)
        {
            var orders = await _orderService.GetUserOrders(customerId);
            if (orders.Any())
            {
                return Ok(orders);
            }
            return NotFound(new { success = false, message = "No orders found" });
        }
        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order != null)
            {
                return Ok(order);
            }
            return NotFound(new { success = false, message = "Order not found" });
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderDTO order)
        {
            var orderID = await _orderService.CreateOrder(order);
            Console.WriteLine(order);
            if (orderID > 0)
            {
                return Ok(new { success = true, message = "Order created successfully",orderID }); 
            }
            else
            {
                return BadRequest(new { success = false, message = "Order creation failed" });
            }

            
        }
        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        void Delete(int id)
        {
            
        }
        [HttpPut("{orderId}/update-payment-status")]
        public async Task< IActionResult> UpdatePaymentStatus(int orderId, [FromBody] PaymentStatus status)
        {
            var success = await _orderService.UpdatePaymentStatus(orderId, status);
            if (! success)
                return NotFound("Order not found");

            return Ok(new { Message = "Payment status updated successfully" });
        }

        [HttpPut("{orderId}/cancel")]
        public async Task< IActionResult> CancelOrder(int orderId)
        {
            var success = await _orderService.CancelOrder(orderId);
            if (!success)
                return NotFound(new { Message = "Order not found or cannot be canceled" });

            return Ok(new { Message = "Order canceled successfully" });
        }
    }
}