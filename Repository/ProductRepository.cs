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
    public class ProductRepository : IProductRepository
    {
        public async Task<IEnumerable<Product>> GetAllProduct() => await ProductDAO.Instance.GetAllProduct();
        public async Task<Product?> GetProductById(int id) => await ProductDAO.Instance.GetProductById(id);
        public async Task<Product?> CreateProduct(Product product) => await ProductDAO.Instance.CreateProduct(product);
        public async Task<Product?> UpdateProduct(int id, Product product) => await ProductDAO.Instance.UpdateProduct(id, product);
        public async Task DeleteProduct(int id) => await ProductDAO.Instance.DeleteProduct(id);
    }
}
