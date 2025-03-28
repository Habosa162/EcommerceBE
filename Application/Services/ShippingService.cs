using ECommerce.API.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Interfaces;

namespace ECommerce.Application.Services
{
    public class ShippingService : IShippingServices
    {
        private readonly IShippingRepository _shippingRepository;
        public ShippingService( IShippingRepository shippingRepository)
        {
            _shippingRepository = shippingRepository;
        }
        public async Task<ShippingDTO> CreateShipping(ShippingDTO shippingDto)
        {
            var newShipping = new Shipping
            {
                OrderId = shippingDto.OrderId,
                ShippingStatus = shippingDto.ShippingStatus,
                Street = shippingDto.Street,
                City = shippingDto.City,
                Gov = shippingDto.Gov,
                Country = shippingDto.Country,
                DeliveryDate = shippingDto.DeliveryDate,
              
            };
            var createdShipping= await _shippingRepository.CreateShipping(newShipping);

            return new ShippingDTO
            {
                Id = createdShipping.Id,
                OrderId = createdShipping.OrderId,
                ShippingStatus = createdShipping.ShippingStatus,
                Street = createdShipping.Street,
                City = createdShipping.City,
                Gov = createdShipping.Gov,
                Country = createdShipping.Country,
                DeliveryDate = createdShipping.DeliveryDate,
            };

        }

        public async Task<bool> DeleteShipping(int id)
        {
            
            return await _shippingRepository.DeleteShipping(id);
        }

        public async Task<IEnumerable<ShippingDTO>> GetAllShippings()
        {
           var shippings = await _shippingRepository.GetAllShippings();
            return shippings.Select(shipping => new ShippingDTO
            {
                Id = shipping.Id,
                OrderId = shipping.OrderId,
                ShippingStatus = shipping.ShippingStatus,
                Street = shipping.Street,
                City = shipping.City,
                Gov = shipping.Gov,
                Country = shipping.Country,
                DeliveryDate = shipping.DeliveryDate,
            });
        }

        public async Task<ShippingDTO> GetShippingById(int id)
        {
            var shipping = await _shippingRepository.GetShippingById(id);
            return new ShippingDTO
            {
                Id = shipping.Id,
                OrderId = shipping.OrderId,
                ShippingStatus = shipping.ShippingStatus,
                Street = shipping.Street,
                City = shipping.City,
                Gov = shipping.Gov,
                Country = shipping.Country,
                DeliveryDate = shipping.DeliveryDate,
            };
        }

        public async Task<ShippingDTO> GetShippingByOrderId(int orderId)
        {
            var shipping = await _shippingRepository.GetShippingByOrderId(orderId);
            if (shipping == null) return null;

            return new ShippingDTO
            {
                Id = shipping.Id,
                OrderId = shipping.OrderId,
                ShippingStatus = shipping.ShippingStatus,
                Street = shipping.Street,
                City = shipping.City,
                Gov = shipping.Gov,
                Country = shipping.Country,
                DeliveryDate = shipping.DeliveryDate,
            };
        }

        public async Task<bool> UpdateShipping(int id, ShippingDTO shippingDto)
        {
            var shipping = await _shippingRepository.GetShippingById(id);
            if (shipping == null) return false;
            shipping.ShippingStatus = shippingDto.ShippingStatus;
            shipping.Street = shippingDto.Street;
            shipping.City = shippingDto.City;
            shipping.Gov = shippingDto.Gov;
            shipping.Country = shippingDto.Country;
            shipping.DeliveryDate = shippingDto.DeliveryDate;
            return await _shippingRepository.UpdateShipping(shipping);
        }
    }
}
