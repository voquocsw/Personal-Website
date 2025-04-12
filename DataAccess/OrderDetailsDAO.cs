using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailsDAO : SingletonBase<OrderDetailsDAO>
    {
        public async Task<IEnumerable<OrderDetails>> GetAllOrderDetails() => await _context.OrderDetails.ToListAsync();

        public async Task<OrderDetails?> GetOrderDetailsById(int ProductId, int OrderId) => await _context.OrderDetails.FirstOrDefaultAsync(o => o.OrderId == OrderId && o.ProductId == ProductId);

        public async Task<OrderDetails> CreateOrderDetails(OrderDetails orderDetails)
        {
            try
            {
                _context.OrderDetails.Add(orderDetails);
                await _context.SaveChangesAsync();
                return orderDetails;
            }catch (Exception ex)
            {
                throw new Exception("(OrderDetailsDAO) Create OrderDetails Error: " + ex.Message);
            }
        }
        public async Task DeleteOrderDetails(int ProductId, int OrderId)
        {
            try
            {
                var orderDetailsDelete = await GetOrderDetailsById(ProductId, OrderId);
                if (orderDetailsDelete != null)
                {
                    _context.OrderDetails.Remove(orderDetailsDelete);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("(OrderDetailsDAO) Delete OrderDetails Error: " + ex.Message);
            }
        }
        public async Task<OrderDetails?> UpdateOrderDetails(OrderDetails orderDetails)
        {
            try
            {
                var orderDetailsUpdate = await GetOrderDetailsById(orderDetails.ProductId, orderDetails.OrderId);
                if (orderDetailsUpdate != null)
                {
                    _context.Entry(orderDetailsUpdate).CurrentValues.SetValues(orderDetails);
                    await _context.SaveChangesAsync();
                    return orderDetails;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("(OrderDetailsDAO) Update OrderDetails Error: " + ex.Message);
            }
        }
    }
}
