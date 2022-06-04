using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Helpers;
using WebApplication5.Interfaces;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private IWebHostEnvironment _webHostEnviornment;
        public ProductController(IProductRepository productRepository,ICategoryRepository categoryRepository
            ,IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnviornment = webHostEnvironment;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var products = _productRepository.GetProduts();

            return View(products);
        }
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> selectedListItems = _categoryRepository.GetCategories().Select(x => new SelectListItem
            {
                Text=x.Name,
                Value = x.CategoryId.ToString()
            });
            ViewBag.CategorySelectedListItem = selectedListItems;
            Product product = new Product();
            if( id ==null)
            {
                return View(product);
            }
            else
            {
                var prod = _productRepository.GetProductById(id??0);
                return View(prod);
            }
        }
        [HttpPost]
        public IActionResult Upsert(Product product)
        {
            product.Image = "temp";
           
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnviornment.WebRootPath;


                if(product.ProductId==0)
                {
                    string upload = webRootPath + WC.ImagePath;
                    string filename = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);
                    using (var stream = new FileStream(Path.Combine(upload, filename + extension), FileMode.Create))
                    {
                        files[0].CopyTo( stream);
                    }

                    product.Image = filename + extension;
                    _productRepository.AddProduct(product);
                    

                }
                else
                {
                    string upload = webRootPath + WC.ImagePath;
                    string filename = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);
                    using (var stream = new FileStream(Path.Combine(upload, filename + extension), FileMode.Create))
                    {
                        files[0].CopyTo(stream);
                    }

                    product.Image = filename + extension;
                    

                    _productRepository.EditProduct(product);
                }
                return RedirectToAction("Index");
            
           // return View(product);
        }
        public IActionResult Delete(int id)
        {
            var prod = _productRepository.GetProductById(id);
            return View(prod);
        }
        public IActionResult Delete(Product product)
        {
            _productRepository.DeleteProduct(product.ProductId);
            return RedirectToAction("Index");
        }
    }
}
