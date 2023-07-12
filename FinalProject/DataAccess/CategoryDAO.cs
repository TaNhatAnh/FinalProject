using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDAO
    {
        public static async Task<List<Category>> GetCategories()
        {
            var listCategories = new List<Category>();
            try
            {
                using (var context = new MyDBContext())
                {
                    listCategories = await context.Categories.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listCategories;
        }

        public static async Task<List<string>> GetCategoryGeneral()
        {
            var listCategoryGeneral = new List<string>();
            try
            {
                using (var context = new MyDBContext())
                {
                    listCategoryGeneral = await context.Categories.Select(x => x.CategoryGeneral).Distinct().ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listCategoryGeneral;
        }

        public static async Task<Category> GetCategoryById(int id)
        {
            Category category = new Category();
            try
            {
                using (var context = new MyDBContext())
                {
                    category = await context.Categories.SingleOrDefaultAsync(x => x.CategoryId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }

        public static async Task<Category> CreateCategory(Category category)
        {
            try
            {
                using (var context = new MyDBContext())
                {
                    await context.Categories.AddAsync(category);
                    await context.SaveChangesAsync();

                    return await context.Categories.SingleOrDefaultAsync(x => x.CategoryId == category.CategoryId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<Category> UpdateCategory(Category category)
        {
            try
            {
                using (var context = new MyDBContext())
                {
                    context.Entry<Category>(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await context.SaveChangesAsync();

                    return await context.Categories.SingleOrDefaultAsync(x => x.CategoryId == category.CategoryId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task DeleteCategory(int id)
        {
            try
            {
                Category category = new Category();
                using (var context = new MyDBContext())
                {
                    category = await context.Categories.SingleOrDefaultAsync(x => x.CategoryId == id);
                    category.IsActive = false;
                    context.Entry<Category>(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
