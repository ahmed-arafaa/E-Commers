using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce_Domain.Entites
{
    public class Order
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Order date is required.")]
        public DateTime OrderDate { get; set; }


        [Required(ErrorMessage = "Order status is required.")]
        [RegularExpression("Pending|Delivered", ErrorMessage = "Status must be 'Pending' or 'Delivered'.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Total price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total price must be greater than 0.")]
        public double? TotalPrice { get; set; }


        [Required(ErrorMessage = "Customer ID is required.")]
        public int CustomerId { get; set; }

        //[Required(ErrorMessage = "Customer is required.")]
        public Customer ? Customer { get; set; }

        [Required(ErrorMessage = "Order must contain at least one product.")]
        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}

