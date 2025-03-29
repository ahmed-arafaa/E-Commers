using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using e_commerce_Domain.Entites;

namespace e_commerce_Application.InterFaces
{
    public interface ICustomer :IGenericRepository<Customer>
    {
        Task<Customer> GetCustomerByEmailAsync(string email);
        Task<Customer> GetCustomerWithOrdersAsync(int customerId);
    }
}
