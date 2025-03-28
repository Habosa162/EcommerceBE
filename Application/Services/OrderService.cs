using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Repositories;

namespace ECommerce.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderRepository _OrderRepository;
        public OrderService(OrderRepository orderRepository)
        {
            _OrderRepository = orderRepository;
        }

        public async Task<bool> CreateOrder(Order order)
        {
            return await _OrderRepository.setOrder(order);
        }

    }
}
