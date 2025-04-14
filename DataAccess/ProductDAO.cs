using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO : SingletonBase<ProductDAO>
    {
        public async Task<IEnumerable<Product>> GetAllProduct() => await _context.Products.ToListAsync();
        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }
        public async Task<Product> CreateProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception("(ProductDAO) Create Product Error: " + ex.Message);
            }
        }
        public async Task<Product?> UpdateProduct(int Id, Product product)
        {
            try
            {
                var productUpdate = await GetProductById(Id);
                if (productUpdate != null)
                {
                    product.ProductId = Id;
                    _context.Entry(productUpdate).CurrentValues.SetValues(product);
                    await _context.SaveChangesAsync();
                    return product;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("(ProductDAO) Update Product Error: " + ex.Message);
            }
        }
        public async Task DeleteProduct(int id)
        {
            try
            {
                var productDelete = await GetProductById(id);
                if (productDelete != null)
                {
                    _context.Products.Remove(productDelete);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("(ProductDAO) Delete Product Error: " + ex.Message);
            }
        }
    }
}
