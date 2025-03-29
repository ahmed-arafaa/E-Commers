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
    public class ProductReprosatoy : GenericRepository<Product>, IProduct
    {
        public ProductReprosatoy(ApplicationDbcontext context):base(context) 
        {
                
        }
        public async Task<IEnumerable<Product>> GetProductsInStockAsync()
        {
 
            var instockprod = await _dbSet.Where(c => c.Stock > 0).ToListAsync();

            return instockprod;
        }

        public async Task<bool> UpdateProductStockAsync(int productId, int quantityChange)
        {
            var updatedProduct = await _dbSet.FindAsync(productId);
            if (updatedProduct == null)
            {
                return false; 
            }

            updatedProduct.Stock += quantityChange; 
            _dbSet.Update(updatedProduct);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}

