using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using e_commerce_Domain.Entites;

namespace e_commerce_Application.InterFaces
{
    public interface IOrder:IGenericRepository<Order>
    {
        Task <bool> UpdateOrderStatusAsync(int orderId, string newStatus);
        Task<Order> GetOrderDetailsAsync(int orderId);
    }
}
