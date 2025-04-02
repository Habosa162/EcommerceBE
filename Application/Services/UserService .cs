using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Interfaces;

namespace ECommerce.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<AppUser> GetUserById(string id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<AppUser> CreateUser(AppUser user, string password)
        {
            return await _userRepository.CreateUser(user, password);
        }

        public async Task<bool> UpdateUser(string id, AppUser user)
        {
            return await _userRepository.UpdateUser(id, user);
        }

        public async Task<bool> DeleteUser(string id)
        {
            return await _userRepository.DeleteUser(id);
        }
    }
}
