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
    public class Category_ProductRepository : ICategory_ProductRepository
    {
        public async Task<IEnumerable<Category_Product>> GetAllCategory_Product() => await Category_ProductDAO.Instance.GetAllCategory_Product();
        public async Task<Category_Product?> GetCategory_ProductById(int ProductId, int CategoryId) => await Category_ProductDAO.Instance.GetCategory_ProductById(CategoryId, ProductId);
        public async Task<Category_Product> CreateCategory_Product(Category_Product category_product) => await Category_ProductDAO.Instance.CreateCategory_Product(category_product);
        public async Task<Category_Product> UpdateCategory_Product(int CategoryId, int ProductId, Category_Product category_product) => await Category_ProductDAO.Instance.UpdateCategory_Product(CategoryId, ProductId, category_product);
        public async Task DeleteCategory_Product(int ProductId, int CategoryId) => await Category_ProductDAO.Instance.DeleteCategory_Product(CategoryId, ProductId);

    }
}
