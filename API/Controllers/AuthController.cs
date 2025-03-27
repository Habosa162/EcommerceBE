using ECommerce.API.DTOs;
using ECommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost]
        //Customer
        //Merchant
        //Admin 
        public async Task<IActionResult> Register([FromBody] RegisterDTO RegisterUser)
        {
            var token = await _authService.register(RegisterUser, "Customer");
            if (token != null)
            {
                return Ok(new { Messsage = "success", token = token });
            }
            else if (token == "exsited")
            {
                return BadRequest(new { Messsage = "user existed" });
            }
            else
            {
                return BadRequest(new { Messsage = "Invalid Data" });
            }
        }

         [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO LoginUser)
        {
            var token = await _authService.login(LoginUser.Email, LoginUser.Password);

            if (token != null)
            {
                return Ok(new { Messsage = "success", token = token });
            }
            else
            {
                return BadRequest(new { Messsage = "Invalid Email or Password" });
            }

        }
    }
}
