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
    public class ProductController : ODataController
    {
        private readonly IProductRepository productRepository;
        public ProductController()
        {
            productRepository = new ProductRepository();
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await productRepository.GetAllProduct();
        }

        [HttpGet("{id}")] 
        public async Task<Product?> GetProductById(int id)
        {
            return await productRepository.GetProductById(id);
        }

        [HttpDelete("{id}")] 
        public async Task DeleteProduct(int id)
        {
            await productRepository.DeleteProduct(id);
        }

        [HttpPut("{id}")] 
        public async Task<Product?> UpdateProduct(int id, Product product)
        {
            return await productRepository.UpdateProduct(id, product);
        }

        [HttpPost] 
        public async Task<Product> CreateProduct(Product product)
        {
            return await productRepository.CreateProduct(product);
        }
    }
}
