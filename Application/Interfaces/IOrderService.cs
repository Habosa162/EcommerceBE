using ECommerce.API.DTOs;
using ECommerce.Domain.Models;

namespace ECommerce.Application.Interfaces
{
    public interface IOrderService
    {
        public Task<int> CreateOrder(OrderDTO orderDto);
        Task<List<OrderDTO>> GetUserOrders(string customerId);
        Task<OrderDTO> GetOrderById(int orderId);


    }
}
