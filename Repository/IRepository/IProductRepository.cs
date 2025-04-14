using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product?> GetProductById(int id);
        Task<Product?> CreateProduct(Product product);
        Task<Product?> UpdateProduct(int id, Product product);
        Task DeleteProduct(int id);
    }
}
