using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace e_commerce_Domain.Entites
{
    public class OrderProduct
    {
        [Required(ErrorMessage = "Order ID is required.")]
        public int OrderId { get; set; }
        [JsonIgnore]
        public Order? Order { get; set; }

        [Required(ErrorMessage = "Product ID is required.")]
        public int ProductId { get; set; }

        public Product? Product { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; } 
    }
}
