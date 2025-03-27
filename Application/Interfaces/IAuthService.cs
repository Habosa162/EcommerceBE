using ECommerce.API.DTOs;
using ECommerce.Domain.Models;

namespace ECommerce.Application.Interfaces
{
    public interface IAuthService
    {
        public bool IsAuthenticated { get; }
        public string? GenerateJwtToken(AppUser user); 
        public Task<string> login(string email, string password);
        public Task<bool> logout();
        public Task<string> register(RegisterDTO registerDTO);
    }
}
