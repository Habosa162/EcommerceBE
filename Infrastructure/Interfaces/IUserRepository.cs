using ECommerce.Domain.Models;

namespace ECommerce.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsers();
        Task<AppUser> GetUserById(string id);
        Task<AppUser> CreateUser(AppUser user , string password);
        Task<bool> UpdateUser(string id, AppUser user);
        Task<bool> DeleteUser(string id);
    }
}
