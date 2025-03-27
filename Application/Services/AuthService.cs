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
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration; 
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
            //new Claim(ClaimTypes.Role, user.Role),
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
        public bool IsAuthenticated => throw new NotImplementedException();

        public Task<string> login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> logout()
        {
            throw new NotImplementedException();
        }

        public Task<string> register(RegisterDTO registerDTO)
        {
            throw new NotImplementedException();
        }




    }
}
