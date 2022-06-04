using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Database;
using WebApplication5.Interfaces;
using WebApplication5.Models;

namespace WebApplication5.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private EcommercContext _eCommercContext;
        public CategoryRepository(EcommercContext ecommercContext)
        {
            _eCommercContext = ecommercContext;
        }

        public void AddCategory(Category category)
        {
            try
            {
                _eCommercContext.categories.Add(category);
                _eCommercContext.SaveChanges();
                    
            }
            catch(Exception ex)
            {
                throw ex ;
            }
        }
        public void EditCategory(Category category)
        {
            try
            {
                _eCommercContext.categories.Update(category);
                _eCommercContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Category> GetCategories()
        {
            try
            {
                return _eCommercContext.categories.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Category GetCategoryById(int id)
        {
            try
            {
                return _eCommercContext.categories.Where(x=> x.CategoryId==id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteCategory(Category id)
        {
            //var categ = _eCommercContext.categories.Where(x => x.CategoryId == id).FirstOrDefault();
            _eCommercContext.categories.Remove(id);
            _eCommercContext.SaveChanges();
        }
    }
}
