using ECommerce.Domain.Enums;
using ECommerce.Domain.Models;

namespace ECommerce.Application.Services
{
    public class ShippingStatusUpdater : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ShippingStatusUpdater> _logger;

        public ShippingStatusUpdater(IServiceProvider serviceProvider, ILogger<ShippingStatusUpdater> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await UpdateShippingStatuses();
                await Task.Delay(TimeSpan.FromHours(24), stoppingToken); // Runs once a day
            }
        }

        private async Task UpdateShippingStatuses()
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var today = DateTime.UtcNow;

                    // Get orders that are still pending and should be shipped
                    var toShipOrders = _context.Shippings
                        .Where(s => s.ShippingStatus == 0 && s.Order.Date.AddDays(1) <= today)
                        .ToList();

                    foreach (var order in toShipOrders)
                    {
                        order.ShippingStatus = ShippingStatus.shipped; // Shipped
                    }

                    // Get orders that should be marked as Delivered
                    var toDeliverOrders = _context.Shippings
                        .Where(s => s.ShippingStatus == ShippingStatus.shipped && s.Order.Date.AddDays(2) <= today)
                        .ToList();

                    foreach (var order in toDeliverOrders)
                    {
                        order.ShippingStatus = ShippingStatus.delivered; // Delivered
                        order.DeliveryDate = today;
                    }

                    await _context.SaveChangesAsync();
                }

                _logger.LogInformation("Shipping statuses updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating shipping statuses: {ex.Message}");
            }
        }
    }
}
