using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;

        public UserRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<AppUser>> GetAllUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<AppUser> GetUserById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }
  
        public async  Task<AppUser> CreateUser(AppUser user ,string password)
        {
            var result = await _userManager.CreateAsync( user,  password);
            if (result.Succeeded)
            {
                return user;
            }
            return null;
        }
        public async Task<bool> UpdateUser(string id, AppUser user)
        {
            var existingUser = await _userManager.FindByIdAsync(id);
            if (existingUser == null) return false;

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.ProfileImage = user.ProfileImage;
            existingUser.BirthDate = user.BirthDate;
            existingUser.IsActive = user.IsActive;

            var result = await _userManager.UpdateAsync(existingUser);
            return result.Succeeded;
        }


        //(Hard delete)
        //public async Task<bool> DeleteUser(string id)
        //{
        //    var user = await _userManager.FindByIdAsync(id);
        //    if (user == null) return false;

        //    var result = await _userManager.DeleteAsync(user);
        //    return result.Succeeded;
        //}

        public async Task<bool> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return false;

            user.IsActive = false; 
            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }



    }
}
