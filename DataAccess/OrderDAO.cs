using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO : SingletonBase<OrderDAO>
    {
        public async Task<IEnumerable<Order>> GetAllOrder() => await _context.Orders.ToListAsync();
        public async Task<Order?> GetOrderById(int id) => await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
        public async Task<Order> CreateOrder(Order order)
        {
            try
            {
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return order;
            }
            catch (Exception ex)
            {
                throw new Exception("(OrderDAO) Create Order Error: " + ex.Message);
            }
        }
        public async Task DeleteOrder(int id)
        {
            try
            {
                var orderDelete = await GetOrderById(id);
                if (orderDelete != null)
                {
                    _context.Orders.Remove(orderDelete);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("(OrderDAO) Delete Order Error: " + ex.Message);
            }
        }
        public async Task<Order?> UpdateOrder(int id, Order order)
        {
            try
            {
                var orderUpdate = await GetOrderById(id);
                if (orderUpdate != null)
                {
                    order.OrderId = id;
                    _context.Entry(orderUpdate).CurrentValues.SetValues(order);
                    await _context.SaveChangesAsync();
                    return order;
                }
                return null;
            }catch (Exception ex) {
                throw new Exception("(OrderDAO) Update Order Error: " + ex.Message);
            }
        }
    }
}
