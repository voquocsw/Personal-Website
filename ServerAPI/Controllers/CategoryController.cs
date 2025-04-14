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
    public class CategoryController :ODataController
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryController()
        {
             categoryRepository = new CategoryRepository();
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await categoryRepository.GetAllCategory();
        }

        [HttpGet("{id}")]
        public async Task<Category?> GetCategoryById(int id)
        {
            return await categoryRepository.GetCategoryById(id);
        }

        [HttpDelete("{id}")] 
        public async Task DeleteCategory(int id)
        {
            await categoryRepository.DeleteCategory(id);
        }

        [HttpPut("{id}")] 
        public async Task<Category?> UpdateCategory(int id, Category category)
        {
            return await categoryRepository.UpdateCategory(id, category);
        }

        [HttpPost]
        public async Task<Category> CreateCategory(Category category)
        {
            return await categoryRepository.CreateCategory(category);
        }
    }
}
