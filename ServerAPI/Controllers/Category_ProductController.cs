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
    public class Category_ProductController : ODataController
    {
        private readonly ICategory_ProductRepository category_productRepository;
        public Category_ProductController()
        {
            category_productRepository = new Category_ProductRepository();
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IEnumerable<Category_Product>> GetAllCategory_Product()
        {
            return await category_productRepository.GetAllCategory_Product();
        }

        [HttpGet("{categoryId}/{productId}")]
        public async Task<Category_Product?> GetCategory_ProductById(int categoryId, int productId)
        {
            return await category_productRepository.GetCategory_ProductById(categoryId, productId);
        }

        [HttpDelete("{categoryId}/{productid}")]
        public async Task DeleteCategory_Product(int categoryId, int productId)
        {
            await category_productRepository.DeleteCategory_Product(categoryId, productId);
        }

        [HttpPost]
        public async Task<Category_Product> CreateCategory_Product(Category_Product category_product)
        {
            return await category_productRepository.CreateCategory_Product(category_product);
        }

        [HttpPost("{categoryId}/{productid}")]
        public async Task<Category_Product> UpdateCategory_Product(int categoryId, int productId, Category_Product category_product)
        {
            return await category_productRepository.UpdateCategory_Product(categoryId, productId, category_product);
        }
    }
}
