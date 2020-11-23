using System;
using System.Collections.Generic;
using Framework.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Framework.Data
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly prod_frameworkContext _context;

        public CategoryRepo(prod_frameworkContext newContext)
        {
            _context = newContext;
        }
        public void CreateCategory(Category cat)
        {
            if (cat == null)

                throw new ArgumentNullException(nameof(cat));

            else _context.Category.Add(cat);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Category.Include(c => c.Card).ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Category
            .Include(c => c.Card)
            .FirstOrDefault(c => c.CategoryId == id);

        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}