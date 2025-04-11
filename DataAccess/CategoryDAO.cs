using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDAO : SingletonBase<CategoryDAO>
    {
        public async Task<IEnumerable<Category>> GetAllCategory() => await _context.Categories.ToListAsync();
        public async Task<Category> GetCategoryById(int id)
        {
            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
                if (category == null)
                {
                    return null;
                }
                return category;
            }
            catch (Exception ex) { 
               throw new Exception("(CategoryDAO) Get Category By Id Error: " + ex.Message);
            }
            
        }
        public async Task<Category> CreateCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception("(CategoryDAO) Create Category Error: " + ex.Message);
            }


        }
        public async Task<Category?> UpdateCategory(Category category)
        {
            try
            {
                var categoryUpdate = GetCategoryById(category.CategoryId);
                if (categoryUpdate != null)
                {
                    _context.Entry(categoryUpdate).CurrentValues.SetValues(category);
                    await _context.SaveChangesAsync();
                    return category;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("(CategoryDAO) Update Category Error: " + ex.Message);
            }

        }
        public async Task DeleteCategory(int id)
        {
            try
            {
                var categoryDelete = await GetCategoryById(id);
                if (categoryDelete != null)
                {
                    _context.Categories.Remove(categoryDelete);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("(CategoryDAO) Delete Category Error: " + ex.Message);
            }
        }
    }
}
