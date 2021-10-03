using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI.Data;
using ShoppingCartAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingCartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly ShoppingCartDBContext _context;

        public ProductCategoryController(ShoppingCartDBContext context)
        {
            _context = context;
        }

       

        // GET: api/<ProductsController>
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategories()
        {
            return await _context.ProductCategories.ToListAsync();
            
        }
    }
}
