using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProduts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void EditProduct(Product product);
        void DeleteProduct(int id);

    }
}
