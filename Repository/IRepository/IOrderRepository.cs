using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order?> GetOrderById(int id);
        Task<Order?> CreateOrder(Order order);
        Task<Order?> UpdateOrder(int id, Order order);
        Task DeleteOrder(int id);
    }
}
