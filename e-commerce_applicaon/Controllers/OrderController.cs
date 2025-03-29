using Microsoft.AspNetCore.Mvc;
using e_commerce_Application.InterFaces;
using e_commerce_Domain.Entites;

namespace e_commerce_applicaon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _orderRepo;
        public OrderController(IOrder orderRepro)
        {
            _orderRepo = orderRepro;
        }

        [HttpPost("CreatOrder")]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            if (order.CustomerId == 0)
            {
                return BadRequest(new { Message = "Customer ID is required." });
            }
            if (order.OrderProducts.Count == 0 || order.OrderProducts == null)
            {
                return BadRequest(new { Message = "Order must contain at least one product." });
            }
            order.Status = "Pending";
            await _orderRepo.AddAsync(order);
            return CreatedAtAction(nameof(GetOrderDetails), new { id = order.Id }, order);


        }
        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetOrderDetails(int id)
        {
            var order = await _orderRepo.GetOrderDetailsAsync(id);
            if (order == null)
            {
                return NotFound(new { Message = "Order not found." });
            }


            var orderDetails = new
            {
                OrderId = order.Id,
                CustomerName = order.Customer.Name,
                Status = order.Status,
                ProductCount = order.OrderProducts.Count
            };

            return Ok(orderDetails);
        }
        [HttpPost("status/update/{id}")]
        public async Task<IActionResult> UpdateOrderStatus(int id, string newStatus)
        {

            if (newStatus != "Delivered" && newStatus != "Pending")
            {
                return BadRequest(new { Message = "Invalid order status. Allowed values: 'Delivered' or 'Pending'." });
            }


            var isUpdated = await _orderRepo.UpdateOrderStatusAsync(id, newStatus);
            if (!isUpdated)
            {
                return NotFound(new { Message = "Order not found." });
            }

            return Ok(new { Message = "Order status updated successfully." });
        }


    }
}
