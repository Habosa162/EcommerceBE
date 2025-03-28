using ECommerce.API.DTOs;
using ECommerce.Domain.Enums;

namespace ECommerce.Application.Interfaces
{
    public interface IShippingServices
    {
        Task<IEnumerable<ShippingDTO>> GetAllShippings();
        Task<ShippingDTO> GetShippingById(int id);
        Task<ShippingDTO> GetShippingByOrderId(int orderId);
        Task<ShippingDTO> CreateShipping(ShippingDTO shippingDto);
        Task<bool> UpdateShippingStatus(int id, ShippingStatus status);
        Task<bool> DeleteShipping(int id);
    }
}
