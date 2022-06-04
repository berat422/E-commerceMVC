using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Interfaces
{
    public interface ICategoryRepository
    {
        public List<Category> GetCategories();
        public Category GetCategoryById(int id);
        void AddCategory(Category category);
        void EditCategory(Category category);
        void DeleteCategory(Category categ);
    }
}
