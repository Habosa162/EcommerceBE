using Amazon.S3;
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
        readonly IAwsService _awsService;   
        readonly IConfiguration _configuration;
        public AuthController(IAuthService authService, IAwsService awsService , IConfiguration configuration)
        {
            _authService = authService;
            _awsService = awsService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterDTO RegisterUser, [FromForm] IFormFile profileImage)
        {
            if (profileImage != null)
            {
                var imageUrl = await _awsService.UploadFileAsync(profileImage, "ProfileImages");
                RegisterUser.ProfileImage = imageUrl;
            }
            var token = await _authService.register(RegisterUser, RegisterUser.Role);
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


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO LoginUser)
        {
            var token = await _authService.login(LoginUser);

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
