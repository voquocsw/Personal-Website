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
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        public async Task<IEnumerable<OrderDetails>> GetAllOrderDetails() => await OrderDetailsDAO.Instance.GetAllOrderDetails();
        public async Task<OrderDetails?> GetOrderDetailsById(int ProductId, int OrderId) => await OrderDetailsDAO.Instance.GetOrderDetailsById(ProductId, OrderId);
        public async Task DeleteOrderDetails(int ProductId, int OrderId) => await OrderDetailsDAO.Instance.DeleteOrderDetails(ProductId, OrderId);
        public async Task<OrderDetails?> CreateOrderDetails(OrderDetails orderDetails) => await OrderDetailsDAO.Instance.CreateOrderDetails(orderDetails);
        public async Task<OrderDetails?> UpdateOrderDetails(OrderDetails orderDetails) => await OrderDetailsDAO.Instance.UpdateOrderDetails(orderDetails);
    }
}
