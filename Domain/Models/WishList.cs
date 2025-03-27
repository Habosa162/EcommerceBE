using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EComm.Domain.Models
{
    public class WishList
    {
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required, ForeignKey("Customer")]
        public string CustomerId { get; set; }

        public Product? Product { get; set; }
        public AppUser? Customer { get; set; }
    }
}
