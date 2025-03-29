using Microsoft.AspNetCore.Mvc;
using e_commerce_Application.InterFaces;
using e_commerce_Domain.Entites;
using NToastNotify;

namespace e_commerce_applicaon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerRepository;
        private readonly IToastNotification _toast;
        

        public CustomerController(ICustomer customerRepository, IToastNotification toast)
        {
            _customerRepository = customerRepository;
            _toast = toast;
        }

        
        [HttpGet]
        

        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllAsync();
            return Ok(customers);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.Name) || string.IsNullOrEmpty(customer.Email))
            {
                return BadRequest(new { Message = "Customer name and email are required." });
            }

            if (!IsValidEmail(customer.Email))
            {
                return BadRequest(new { Message = "Invalid email format." });
            }

            await _customerRepository.AddAsync(customer);
            //_toast.AddSuccessToastMessage("Customer Added Succefully");
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound(new { Message = "Customer not found." });
            }

            return Ok(customer);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
