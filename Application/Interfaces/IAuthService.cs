using ECommerce.API.DTOs;
using ECommerce.Domain.Models;

namespace ECommerce.Application.Interfaces
{
    public interface IAuthService
    {
        public Task<bool> IsAuthenticated(string email); 
        public string? GenerateJwtToken(AppUser user); 
        public Task<string> login(string email, string password);
        public Task<bool> logout();
        public Task<string> register(RegisterDTO registerDTO, string role);
    }
}
