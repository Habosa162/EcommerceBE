using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(string id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<AppUser>> CreateUser(AppUser user, string password)
        {
            var createdUser = await _userService.CreateUser(user, password);
            if (createdUser == null)
            {
                return BadRequest("User creation failed");
            }
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, AppUser user)
        {
            var result = await _userService.UpdateUser(id, user);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUser(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
