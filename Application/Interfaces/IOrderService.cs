using ECommerce.API.DTOs;
using ECommerce.Domain.Models;

namespace ECommerce.Application.Interfaces
{
    public interface IOrderService
    {
        public Task<bool> CreateOrder(OrderDTO orderDto);
        Task<List<Order>> GetUserOrders(string customerId);
        Task<Order?> GetOrderById(int orderId);


    }
}
