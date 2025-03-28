using ECommerce.Application.Interfaces;
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

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            var res = await _orderService.CreateOrder(order);
            if (res)
            {
                return Ok(new { success = true, message = "Order created successfully" });
            }
            else
            {
                return BadRequest(new { success = false, message = "Order creation failed" });
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
        }
    }
}