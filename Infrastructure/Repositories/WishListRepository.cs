using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories
{
    public class WishListRepository : IWishListRepository

    {
        private readonly ApplicationDbContext _context;
        public WishListRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddToWishlist(WishList wishlistItem)
        {
            await _context.WishLists.AddAsync(wishlistItem);
            await _context.SaveChangesAsync();  
        }

        public async Task<WishList> GetWishListByID(int wishListItemId)
        {
            var item = await _context.WishLists.FirstOrDefaultAsync(w=>w.Id==wishListItemId);
            return item; 
        }

        public async Task<IEnumerable<WishList>> GetWishlistByUser(string userId)
        {
            return await _context.WishLists.Where(w => w.CustomerId == userId).Include(w=>w.Product).ToListAsync();
        }

        public async Task<WishList> GetWishListItem(string userId, int productId)
        {
             return await _context.WishLists.FirstOrDefaultAsync(w => w.CustomerId == userId && w.ProductId == productId);
        }

        public async Task RemoveFromWishlist(int wishListItemId)
        {
            var DeleteItem = _context.WishLists.FirstOrDefault(w => w.Id == wishListItemId);
            if (DeleteItem != null)
            {
                 _context.WishLists.Remove(DeleteItem);
                 await _context.SaveChangesAsync();
            }
        }
    }
}
