using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Database;
using WebApplication5.Interfaces;
using WebApplication5.Models;

namespace WebApplication5.Repository
{
    public class ProductRepository : IProductRepository
    {
        private EcommercContext _context;
        public ProductRepository(EcommercContext ecommercContext)
        {
            _context = ecommercContext;
        }
        public void AddProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }

        public void EditProduct(Product product)
        {
            _context.products.Update(product);
            _context.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            return _context.products.Where(x => x.ProductId == id).FirstOrDefault();
        }

        public List<Product> GetProduts()
        {
            return _context.products.ToList();
        }
        public void DeleteProduct(int id)
        {

        }
    }
}
