using ECommerce.Domain.Models;

namespace ECommerce.Infrastructure.Interfaces
{
    public interface IWishListRepository
    {
        Task<IEnumerable<WishList>> GetWishlistByUser(string userId);
        Task AddToWishlist(WishList wishlistItem);
        Task RemoveFromWishlist(int productId);

        Task<WishList> GetWishListItem(string userId,int productId);
    }
}
