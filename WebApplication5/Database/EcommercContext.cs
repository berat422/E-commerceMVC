using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Database
{
    public class EcommercContext:DbContext
    {
        public EcommercContext(DbContextOptions<EcommercContext> options ):base(options)
        {

        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
    }
}
