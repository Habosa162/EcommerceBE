using EComm.Domain.Models;

namespace EComm.Infrastructure.Interfaces
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> GetOrders(); 
        public Task<Order?> GetOrder(int id);
        public Task setOrder(Order order);
        public Task deleteOrder(int id);    
        public Task updateOrder(Order order);
        public Task<OrderItem?> GetOrderItem(int orderItemId);
        public Task<IEnumerable<OrderItem>> GetOrderItems(int OrderID); 

    }
}
