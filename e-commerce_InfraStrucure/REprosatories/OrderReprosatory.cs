using e_commerce_Application.InterFaces;
using e_commerce_Domain.Entites;
using e_commerce_InfraStrucure.Data;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_InfraStrucure.REprosatories
{
    public class OrderReprosatory : GenericRepository<Order>, IOrder
    {
        public OrderReprosatory(ApplicationDbcontext context) : base(context)
        {
        }

        public async Task<Order?> GetOrderDetailsAsync(int orderId)
        {
            return await _dbSet
                .Include(o => o.Customer)
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<bool> UpdateOrderStatusAsync(int orderId, string newStatus)
        {
            
            if (newStatus != "Delivered" && newStatus != "Pending")
            {
                return false; 
            }

            var order = await _dbSet.Include(o => o.OrderProducts).FirstOrDefaultAsync(o => o.Id == orderId);
            if (order == null)
            {
                return false; 
            }

            
            order.Status = newStatus;

          
            if (newStatus == "Delivered")
            {
                foreach (var orderProduct in order.OrderProducts)
                {
                    var product = await _context.Set<Product>().FindAsync(orderProduct.ProductId);
                    if (product != null)
                    {
                        product.Stock -= orderProduct.Quantity;
                        _context.Set<Product>().Update(product);
                    }
                }
            }

            
            await _context.SaveChangesAsync();

            return true; 
        }
    }
}
