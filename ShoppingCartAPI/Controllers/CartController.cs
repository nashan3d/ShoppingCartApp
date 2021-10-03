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
    public class CartController : ControllerBase
    {
        private readonly ShoppingCartDBContext _context;

        public CartController(ShoppingCartDBContext context)
        {
            _context = context;
        }

        // GET: api/<CartController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            return await _context.Carts.ToListAsync();
        }


        // POST api/<CartController>
        [HttpPost]        
        public async Task<ActionResult<Cart>> PostCarts(Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarts", new { id = cart.Id}, cart);

        }


        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
                return NotFound();

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
