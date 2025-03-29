using ECommerce.API.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Interfaces;
using ECommerce.Infrastructure.Repositories;

namespace ECommerce.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _OrderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _OrderRepository = orderRepository;
        }

        public async Task<int> CreateOrder(OrderDTO orderDto)
        {
            var order = new Order
            {
                Date = DateTime.UtcNow,
                TotalAmount = orderDto.TotalAmount,
                CustomerId = orderDto.CustomerId,
                PaymentStatus = (PaymentStatus)orderDto.PaymentStatus,
                OrderItems = orderDto.OrderItems.Select(item => new OrderItem
                {
                    Name = item.Name,
                    ProductId = item.ProductId,
                    UnitPrice = item.UnitPrice,
                    Qty = item.Qty
                }).ToList()
            };
             await _OrderRepository.setOrder(order);
            return order.Id;
        }
        public async Task<List<OrderDTO>> GetUserOrders(string customerId)
        {
            return await _OrderRepository.GetUserOrders(customerId);
        }

        public async Task<OrderDTO?> GetOrderById(int orderId)
        {
            return await _OrderRepository.GetOrder(orderId);
        }
    }
}
