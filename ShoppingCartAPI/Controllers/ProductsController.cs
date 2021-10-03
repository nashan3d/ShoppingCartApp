using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI.Data;
using ShoppingCartAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingCartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShoppingCartDBContext _context;

        public ProductsController(ShoppingCartDBContext context)
        {
            _context = context;
        }

        // GET: api/<ProductsController>
        [HttpGet("{productCategoryId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(int productCategoryId)        
        {
            var products = await _context.Products.Where(x => x.ProductCategory.Id == productCategoryId).ToListAsync();
            if (products == null)
            {
                return NotFound();
            }
            return products;
        }

        
    }
}
