using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategory();
        Task<Category?> GetCategoryById(int id);
        Task<Category?> CreateCategory(Category category);
        Task<Category?> UpdateCategory(int id, Category category);
        Task DeleteCategory(int id);
    }
}
