using ECommerce.API.DTOs;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Models;

namespace ECommerce.Application.Interfaces
{
    public interface IOrderService
    {
        public Task<int> CreateOrder(OrderDTO orderDto);
        public Task<IEnumerable<OrderDTO>> GetOrders();
        public Task<List<OrderDTO>> GetUserOrders(string customerId);
        public Task<OrderDTO> GetOrderById(int orderId);
        public Task<bool> UpdatePaymentStatus(int orderId, PaymentStatus newStatus);
        public Task<bool> CancelOrder(int orderId);



    }
}
