using BussinessObject;
using DataAccess;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<IEnumerable<Order>> GetAllOrders() => await OrderDAO.Instance.GetAllOrder();
        public async Task<Order?> GetOrderById(int id) => await OrderDAO.Instance.GetOrderById(id);
        public async Task<Order?> CreateOrder(Order order) => await OrderDAO.Instance.CreateOrder(order);
        public async Task<Order?> UpdateOrder(int id, Order order) => await OrderDAO.Instance.UpdateOrder(id, order);
        public async Task DeleteOrder(int id) => await OrderDAO.Instance.DeleteOrder(id);
    }
}
