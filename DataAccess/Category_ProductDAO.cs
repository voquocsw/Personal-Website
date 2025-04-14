using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Category_ProductDAO : SingletonBase<Category_ProductDAO>
    {
        public async Task<IEnumerable<Category_Product>> GetAllCategory_Product() => await _context.Category_Products.ToListAsync();
        public async Task<Category_Product?> GetCategory_ProductById(int CategoryId, int ProductId) => await _context.Category_Products.FirstOrDefaultAsync(cp => cp.CategoryId == CategoryId && cp.ProductId == ProductId);
        public async Task<Category_Product> CreateCategory_Product(Category_Product category_product)
        {
            try
            {
                await _context.Category_Products.AddAsync(category_product);
                await _context.SaveChangesAsync();
                return category_product;
            }
            catch (Exception ex) {
                throw new Exception("(Category_ProductDAO) Create Category_Product Error: " + ex.Message);
            }
        }
        public async Task DeleteCategory_Product(int CategoryId, int ProductId)
        {
            try
            {
                var category_productDelete = await GetCategory_ProductById(CategoryId, ProductId);
                if (category_productDelete != null)
                {
                    _context.Category_Products.Remove(category_productDelete);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex) {
                throw new Exception("(Category_ProductDAO) Delete Category_Product Error: " + ex.Message);
            }
        }
        public async Task<Category_Product?> UpdateCategory_Product(int CategoryId, int ProductId, Category_Product category_product)
        {
            try
            {
                var category_productUpdate = await GetCategory_ProductById(CategoryId, ProductId);
                if (category_productUpdate != null)
                {
                    category_product.CategoryId = CategoryId;
                    category_product.ProductId = ProductId;
                    _context.Entry(category_productUpdate).CurrentValues.SetValues(category_product);
                    await _context.SaveChangesAsync();
                    return category_product;
                }
                return null;
            }
            catch (Exception ex) {
                throw new Exception("(Category_ProductDAO) Update Category_Product Error: " + ex.Message);
            }
        }
    }
}
