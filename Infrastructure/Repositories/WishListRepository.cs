using EComm.Domain.Models;
using EComm.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EComm.Infrastructure.Repositories
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

        public async Task<IEnumerable<WishList>> GetWishlistByUser(string userId)
        {
            return await _context.WishLists.Where(w => w.CustomerId == userId).Include(w=>w.Product).ToListAsync();
        }

        public async Task<WishList> GetWishListItem(string userId, int productId)
        {
             return await _context.WishLists.FirstOrDefaultAsync(w => w.CustomerId == userId && w.ProductId == productId);
        }

        public async Task RemoveFromWishlist(int productId)
        {
            var DeleteItem = _context.WishLists.FirstOrDefault(w => w.ProductId == productId);
            if (DeleteItem != null)
            {
                 _context.WishLists.Remove(DeleteItem);
                 await _context.SaveChangesAsync();
            }
        }
    }
}
