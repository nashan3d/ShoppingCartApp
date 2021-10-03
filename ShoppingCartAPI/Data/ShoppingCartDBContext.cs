using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartAPI.Data
{
    public class ShoppingCartDBContext :DbContext
    {
        public ShoppingCartDBContext(DbContextOptions<ShoppingCartDBContext> options):base(options)
        {

        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}
