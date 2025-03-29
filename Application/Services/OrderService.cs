using ECommerce.API.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Interfaces;
using ECommerce.Infrastructure.Repositories;

namespace ECommerce.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IShippingRepository _shippingRepository;
        public OrderService(IOrderRepository orderRepository, IShippingRepository shippingRepository)
        {
            _OrderRepository = orderRepository;
            _shippingRepository = shippingRepository;
        }

        public async Task<int> CreateOrder(OrderDTO orderDto)
        {
            var order = new Order
            {
                Date = DateTime.UtcNow,
                TotalAmount = orderDto.TotalAmount,
                CustomerId = orderDto.CustomerId,
                PaymentStatus = (PaymentStatus)orderDto.PaymentStatus,
                OrderItems = orderDto.OrderItems.Select(item => new OrderItem
                {
                    Name = item.Name,
                    ProductId = item.ProductId,
                    UnitPrice = item.UnitPrice,
                    Qty = item.Qty
                }).ToList()
            };
             await _OrderRepository.setOrder(order);
            return order.Id;
        }
        public async Task<List<OrderDTO>> GetUserOrders(string customerId)
        {
            return await _OrderRepository.GetUserOrders(customerId);
        }

        public async Task<OrderDTO?> GetOrderById(int orderId)
        {
            return await _OrderRepository.GetOrder(orderId);
        }
        public async Task<bool> UpdatePaymentStatus(int orderId, PaymentStatus newStatus)
        {
            var order = await _OrderRepository.GetOrderByID(orderId);
            if (order == null)
                return false;

            order.PaymentStatus = newStatus;
            await _OrderRepository.updateOrder(order);

            return true;
        }
        public async Task<bool> CancelOrder(int orderId)
        {
            var order = await _OrderRepository.GetOrder(orderId);
            if (order.PaymentStatus == PaymentStatus.Paid)
            {
                await UpdatePaymentStatus(orderId, PaymentStatus.Refunded);
            }
            else if(order.PaymentStatus == PaymentStatus.Pending)
            {
                var shippingData = await _shippingRepository.GetAllShippings();
                foreach (var item in shippingData)
                {
                    if (item.OrderId == orderId)
                        await _shippingRepository.DeleteShipping(item.Id);
                }
                await _OrderRepository.deleteOrder(orderId);
            }
            else
            {
                return false;
            }
            return true;
        }
        

    }
}
