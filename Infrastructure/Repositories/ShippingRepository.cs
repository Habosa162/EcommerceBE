using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories
{
    public class ShippingRepository : IShippingRepository
    {
        private readonly ApplicationDbContext _context;
        public ShippingRepository(ApplicationDbContext context )
        {
            _context = context;
        }
        public async Task<Shipping> CreateShipping(Shipping shipping)
        {
            await _context.Shippings.AddAsync(shipping);
            await _context.SaveChangesAsync();
            return shipping;
        }

        public async Task<bool> DeleteShipping(int id)
        {
            var shipping = await GetShippingById(id);
            if (shipping == null) return false;

            _context.Shippings.Remove(shipping);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Shipping>> GetAllShippings()
        {
            return await _context.Shippings.Include(s=>s.Order).ToListAsync();
        }

        public async Task<Shipping> GetShippingById(int id)
        {
            return await _context.Shippings.Include(s => s.Order).FirstOrDefaultAsync(s=>s.Id==id);
        }

        public async Task<Shipping> GetShippingByOrderId(int orderId)
        {
            return await _context.Shippings.Include(s => s.Order).FirstOrDefaultAsync(s => s.OrderId == orderId);
        }

        public async Task<bool> UpdateShipping(Shipping shipping)
        {
            _context.Shippings.Update(shipping);
            return await _context.SaveChangesAsync() > 0;
        }
 
    }
}
