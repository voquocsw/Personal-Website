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
    public class CategoryRepository : ICategoryRepository
    {
        public async Task<IEnumerable<Category>> GetAllCategory() => await CategoryDAO.Instance.GetAllCategory();
        public async Task<Category?> GetCategoryById(int id) => await CategoryDAO.Instance.GetCategoryById(id);
        public async Task<Category?> CreateCategory(Category category) => await CategoryDAO.Instance.CreateCategory(category);
        public async Task<Category?> UpdateCategory(int id, Category category) => await CategoryDAO.Instance.UpdateCategory(id, category);
        public async Task DeleteCategory(int id) => await CategoryDAO.Instance.DeleteCategory(id);
    }
}
