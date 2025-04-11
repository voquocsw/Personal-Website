using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IOrderDetailsRepository
    {
        Task<IEnumerable<OrderDetails>> GetAllOrderDetails();
        Task<OrderDetails?> GetOrderDetailsById(int ProductId, int OrderId);
        Task<OrderDetails?> CreateOrderDetails(OrderDetails orderDetails);
        Task<OrderDetails?> UpdateOrderDetails(OrderDetails orderDetails);
        Task DeleteOrderDetails(int ProductId, int OrderId);
    }
}
