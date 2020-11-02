using System.Collections.Generic;
using Framework.Models;
namespace Framework.Data
{
    public interface ICategoryRepo
    {
        bool SaveChanges();
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
        void CreateCategory(Category cat);
    }
}