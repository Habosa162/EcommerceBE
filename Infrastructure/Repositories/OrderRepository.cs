using ECommerce.API.DTOs;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using static NuGet.Packaging.PackagingConstants;

namespace ECommerce.Infrastructure.Repositories
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
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<OrderDTO> GetOrder(int id)
        {
            var order = await _context.Orders
                .Include(o=>o.Customer)
                .Include(o=>o.OrderItems)
                .ThenInclude(o=>o.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
            return new OrderDTO
            {
                id = order.Id,
                OrderDate = order.Date,
                CustomerId = order.CustomerId,
                TotalAmount = order.TotalAmount,
                PaymentStatus = order.PaymentStatus,
                OrderItems = order.OrderItems.Select(oi => new OrderItemDto
                {
                    Name = oi.Name,
                    ProductId = oi.ProductId,
                    UnitPrice = oi.UnitPrice,
                    Qty = oi.Qty,
                    productImg = oi.Product.ImgUrl
                }).ToList()
            };
        }
        public async Task<Order> GetOrderByID(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(o => o.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
            return order;
        }
        public async Task<IEnumerable<OrderDTO>> GetOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToListAsync();
            return orders.Select(o => new OrderDTO
            {
                id = o.Id,
                OrderDate = o.Date,
                CustomerId = o.CustomerId,
                TotalAmount = o.TotalAmount,
                PaymentStatus = o.PaymentStatus,
                OrderItems = o.OrderItems.Select(oi => new OrderItemDto
                {
                    Name = oi.Name,
                    ProductId = oi.ProductId,
                    UnitPrice = oi.UnitPrice,
                    Qty = oi.Qty
                }).ToList()
            }).ToList();
        }

        public async Task<bool> setOrder(Order order)
        {
            try
            {
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
             if(e is DbUpdateException)
                {
                    return false;
                }
                throw;
            }

        }
        public ShippingStatus GetShippingStatusByOrderId(int OrderID)
        {
            return _context.Shippings.FirstOrDefault(s => s.OrderId == OrderID).ShippingStatus;
        }
        public async Task<List<OrderDTO>> GetUserOrders(string customerId)
        {
            var orders = await _context.Orders
                .Where(o => o.CustomerId == customerId)
                .Include(o => o.OrderItems)
                .ThenInclude(oi=>oi.Product)
                .ToListAsync();
            if (orders == null)
                return new List<OrderDTO>();
            return orders?.Select(o => new OrderDTO
            {
                id = o.Id,
                OrderDate = o.Date,
                CustomerId = o.CustomerId,
                TotalAmount = o.TotalAmount,
                PaymentStatus = o.PaymentStatus,
                OrderItems = o.OrderItems.Select(oi => new OrderItemDto
                {
                    Name = oi.Name,
                    ProductId = oi.ProductId,
                    UnitPrice = oi.UnitPrice,
                    Qty = oi.Qty,
                    productImg = oi.Product.ImgUrl
                }
                ).ToList(),

                ShippingStatus = (o.PaymentStatus == PaymentStatus.Pending || o.PaymentStatus == PaymentStatus.Paid)
                ? _context.Shippings.FirstOrDefault(s => s.OrderId == o.Id)?.ShippingStatus
                : null,



                DelivaryDate = (o.PaymentStatus == PaymentStatus.Pending || o.PaymentStatus == PaymentStatus.Paid)
        ? _context.Shippings.FirstOrDefault(s => s.OrderId == o.Id)?.DeliveryDate
        : null


            }).ToList();
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
