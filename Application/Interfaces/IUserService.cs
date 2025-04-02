using ECommerce.Domain.Models;

namespace ECommerce.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<AppUser>> GetAllUsers();

        Task<AppUser> GetUserById(string id);

    
        Task<AppUser> CreateUser(AppUser user, string password);

        Task<bool> UpdateUser(string id, AppUser user);

 
        Task<bool> DeleteUser(string id);
    }
}
