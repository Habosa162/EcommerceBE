using ECommerce.Domain.Models;

namespace ECommerce.Application.Interfaces
{
    public interface IOrderService
    {
        public Task<bool> CreateOrder(Order order);  


    }
}
