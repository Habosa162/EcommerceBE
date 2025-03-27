using EComm.Domain.Models;
using EComm.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EComm.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context; 
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task deleteOrder(int id)
        {
            var order = await GetOrder(id);
            if (order != null) {

                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Order?> GetOrder(int id)
        {
            return await _context.Orders
                .Include(o=>o.Customer)
                .Include(o=>o.OrderItems)
                //.ThenInclude(o=>o.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task setOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();  
        }

        public async Task updateOrder(Order order)
        {
           _context.Orders.Update(order);
            await _context.SaveChangesAsync();

        }


        public async Task<OrderItem?> GetOrderItem(int orderItemId)
        {
            return await _context.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.Product)
                .FirstOrDefaultAsync(oi => oi.Id == orderItemId); 
        }
        public async Task<IEnumerable<OrderItem>> GetOrderItems(int OrderID)
        {
            return await _context.OrderItems
                .Where(oi => oi.OrderId == OrderID)
                .Include(oi => oi.Product)
                .ToListAsync();
        }

    }
}
