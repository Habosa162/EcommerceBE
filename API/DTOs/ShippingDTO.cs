using ECommerce.Domain.Enums;
using ECommerce.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.DTOs
{
    public class ShippingDTO
    {



   
        public int Id { get; set; }


        public DateTime? DeliveryDate { get; set; }

        
        public ShippingStatus ShippingStatus { get; set; } = ShippingStatus.pending;



        public int OrderId { get; set; }


        public string Country { get; set; } = string.Empty;


        public string City { get; set; } = string.Empty;


        public string Gov { get; set; } = string.Empty;


        public string Street { get; set; } = string.Empty;
    }
}
