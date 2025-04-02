using ECommerce.Domain.Models;

namespace ECommerce.Application.Interfaces
{
    public interface IWishListService
    {
       public Task<IEnumerable<WishList>> GetWishlistByUser(string userId);
       public Task<bool> AddToWishlist(string userId, int productId);
       public Task<bool> RemoveFromWishlist(int wishListItemId);
    }
}
