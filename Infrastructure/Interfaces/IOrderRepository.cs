using ECommerce.API.DTOs;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Models;

namespace ECommerce.Infrastructure.Interfaces
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<OrderDTO>> GetOrders(); 
        public Task deleteOrder(int id);    
        public Task updateOrder(Order order);
        public Task<OrderItem?> GetOrderItem(int orderItemId);
        public Task<IEnumerable<OrderItem>> GetOrderItems(int OrderID);
        public Task<Order> GetOrderByID(int id);


        public Task<OrderDTO> GetOrder(int id);
        public Task<bool> setOrder(Order order);
        public Task<List<OrderDTO>> GetUserOrders(string customerId);
        public ShippingStatus GetShippingStatusByOrderId(int OrderID);
    }
}
