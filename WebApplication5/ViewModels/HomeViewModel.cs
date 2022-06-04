using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.ViewModels
{
    public class HomeViewModel
    {
        public List<Category> categories { get; set; }
        public List<Product> products { get; set; }
    }
}
