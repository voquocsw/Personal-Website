using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Repository;
using Repository.IRepository;

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ODataController
    {
        private readonly IOrderRepository orderRepository;
        public OrderController()
        {
            orderRepository = new OrderRepository();
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await orderRepository.GetAllOrders();
        }

        [HttpGet]
        public async Task<Order?> GetOrderById(int id)
        {
            return await orderRepository.GetOrderById(id);
        }

        [HttpDelete("{id}")] 
        public async Task DeleteOrder(int id)
        {
            await orderRepository.DeleteOrder(id);
        }

        [HttpPut("{id}")] 
        public async Task<Order?> UpdateOrder(int id, Order order)
        {
            return await orderRepository.UpdateOrder(id, order);
        }

        [HttpPost] 
        public async Task<Order> CreateOrder(Order order)
        {
            return await orderRepository.CreateOrder(order);
        }
    }
}
