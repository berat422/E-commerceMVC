using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Interfaces;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {

            var categories = _categoryRepository.GetCategories();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View(category);
            }
            _categoryRepository.AddCategory(category);
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(int id)

        {
            var categ = _categoryRepository.GetCategoryById(id);
            return View(categ);
        }
        [HttpPost]
        public IActionResult Edit(Category categ)

        {
            _categoryRepository.EditCategory(categ);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var categ = _categoryRepository.GetCategoryById(Id);
            return View(categ);
        }

        public IActionResult DeleteCategory(Category categ)
        {
            _categoryRepository.DeleteCategory(categ);
            return RedirectToAction("Index");
        }

    }
}
