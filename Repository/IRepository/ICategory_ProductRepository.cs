using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ICategory_ProductRepository
    {
        Task<IEnumerable<Category_Product>> GetAllCategory_Product();
        Task<Category_Product> GetCategory_ProductById(int CategoryId, int ProductId);
        Task<Category_Product> CreateCategory_Product(Category_Product category_product);
        Task<Category_Product> UpdateCategory_Product(Category_Product category_product);
        Task DeleteCategory_Product(int CategoryId, int ProductId);
    }
}
