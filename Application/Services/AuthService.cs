using ECommerce.API.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerce.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        //private readonly RoleManager<AppUser> _roleManager;
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration
            //, RoleManager<AppUser> roleManager
            , UserManager<AppUser> userManager
            )
        {
            _configuration = configuration;
            //_roleManager = roleManager;
            _userManager = userManager;
        }

        //test
        public string? GenerateJwtToken(AppUser user)
        {
            if (user != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                   
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.FirstName),
                    new Claim(ClaimTypes.Name, user.LastName),
                    new Claim(ClaimTypes.Role, _userManager.GetRolesAsync(user).ToString() ),
                 };

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(3),
                    signingCredentials: credentials
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
            {
                return null;
            }
        }


        public async Task<string> register(RegisterDTO registerDTO, string role)
        {
            if (registerDTO == null)
            {
                return null; 
            }
            if(await IsAuthenticated(registerDTO.Email))
            {
                return "existed";
            }

            var user = new AppUser
            {
                FirstName = registerDTO.FName,
                LastName = registerDTO.LName,
                Email = registerDTO.Email,
                UserName = registerDTO.Email,
                ProfileImage = registerDTO.ProfileImage
            };
            await _userManager.CreateAsync(user, registerDTO.Password);
            if (!string.IsNullOrEmpty(role))
            {
                await _userManager.AddToRoleAsync(user, role);
            }
            return GenerateJwtToken(user);  
        }

        public async Task<string> login(LoginDTO LoginUser)
        {

            if(await IsAuthenticated(LoginUser.Email))
            {
                var user = await _userManager.FindByEmailAsync(LoginUser.Email);
                if (await _userManager.CheckPasswordAsync(user, LoginUser.Password))
                {
                    return GenerateJwtToken(user);
                }
                else
                {
                    return null;
                }
            }
            else
            {
               return null;
            }
        }

        public Task<bool> logout()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsAuthenticated(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            return !(user == null);
        }

    }
}
