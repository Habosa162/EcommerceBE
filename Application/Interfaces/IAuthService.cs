using ECommerce.API.DTOs;
using ECommerce.Domain.Models;

namespace ECommerce.Application.Interfaces
{
    public interface IAuthService
    {
        public Task<bool> IsAuthenticated(string email); 
        public Task<string?> GenerateJwtTokenAsync(AppUser user); 
        public Task<string> login(LoginDTO loginDto);
        public Task<bool> logout();
        public Task<string> register(RegisterDTO registerDTO, string role);
    }
}
