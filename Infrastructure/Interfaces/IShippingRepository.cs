using ECommerce.Domain.Models;

namespace ECommerce.Infrastructure.Interfaces
{
    public interface IShippingRepository
    {
        Task<IEnumerable<Shipping>> GetAllShippings();
        Task<Shipping> GetShippingById(int id);
        Task<Shipping> GetShippingByOrderId(int orderId);
        Task<Shipping> CreateShipping(Shipping shipping);
        Task<bool> UpdateShipping(Shipping shipping);
        Task<bool> DeleteShipping(int id);
    }
}
