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
    public class OrderDetailsController : ODataController
    {
        private readonly IOrderDetailsRepository orderDetailRepository;

        public OrderDetailsController()
        {
            orderDetailRepository = new OrderDetailsRepository();
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IEnumerable<OrderDetails>> GetAllOrderDetails()
        {
            return await orderDetailRepository.GetAllOrderDetails();
        }

        [HttpGet("{productId}/{orderId}")]
        public async Task<OrderDetails?> GetOrderDetailsById(int ProductId, int OrderId)
        {
            return await orderDetailRepository.GetOrderDetailsById(ProductId, OrderId);
        }

        [HttpDelete("{productId}/{orderId}")]
        public async Task DeleteOrderDetails(int productId, int orderId)
        {
            await orderDetailRepository.DeleteOrderDetails(productId, orderId);
        }

        [HttpPut("{productId}/{orderId}")] 
        public async Task<OrderDetails?> UpdateOrderDetails(int productId, int orderId, OrderDetails orderDetails)
        {
            return await orderDetailRepository.UpdateOrderDetails(productId, orderId, orderDetails);
        }

        [HttpPost("{productId}/{orderId}")] 
        public async Task<OrderDetails> CreateOrderDetails(int productId, int orderId, OrderDetails orderDetails)
        {
            return await orderDetailRepository.CreateOrderDetails(orderDetails);
        }
    }
}
