using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Interfaces;
using WebApplication5.Models;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        public HomeController(ILogger<HomeController> logger,ICategoryRepository categ,IProductRepository product)
        {
            _logger = logger;
            _categoryRepository = categ;
            _productRepository = product;

        }

        public IActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel();
            vm.categories = _categoryRepository.GetCategories();
            vm.products = _productRepository.GetProduts();

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
