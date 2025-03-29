using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using e_commerce_Application.InterFaces;
using e_commerce_Domain.Entites;
using e_commerce_InfraStrucure.Data;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_InfraStrucure.REprosatories
{
    public class CustomerReprosatory : GenericRepository<Customer>, ICustomer
    {
        public CustomerReprosatory(ApplicationDbcontext context):base(context) 
        {
                
        }
        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Email == email) ?? null;
        }

                    
        

        public async Task<Customer> GetCustomerWithOrdersAsync(int customerId)
        {
            var customerorder = await _dbSet
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(c => c.Id == customerId);
            return customerorder;


        }
    }
}
