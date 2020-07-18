using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShopperAPI.Models;

namespace MyShopperAPI.Controllers
{
    [Route("api/ShoppingListProducts")]
    [ApiController]
    public class ShoppingListProductsController : ControllerBase
    {
        private readonly MyShopperContext _context;

        public ShoppingListProductsController(MyShopperContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingListProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingListProduct>>> GetShoppingListProduct()
        {
            return await _context.ShoppingListProduct.ToListAsync();
        }

        // GET: api/ShoppingListProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingListProduct>> GetShoppingListProduct(int id)
        {
            var shoppingListProduct = await _context.ShoppingListProduct.FindAsync(id);

            if (shoppingListProduct == null)
            {
                return NotFound();
            }

            return shoppingListProduct;
        }

        // PUT: api/ShoppingListProducts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingListProduct(int id, ShoppingListProduct shoppingListProduct)
        {
            if (id != shoppingListProduct.ShoppingListProductId)
            {
                return BadRequest();
            }

            _context.Entry(shoppingListProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingListProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ShoppingListProducts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShoppingListProduct>> PostShoppingListProduct(ShoppingListProduct shoppingListProduct)
        {
            _context.ShoppingListProduct.Add(shoppingListProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingListProduct", new { id = shoppingListProduct.ShoppingListProductId }, shoppingListProduct);
        }

        // DELETE: api/ShoppingListProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShoppingListProduct>> DeleteShoppingListProduct(int id)
        {
            var shoppingListProduct = await _context.ShoppingListProduct.FindAsync(id);
            if (shoppingListProduct == null)
            {
                return NotFound();
            }

            _context.ShoppingListProduct.Remove(shoppingListProduct);
            await _context.SaveChangesAsync();

            return shoppingListProduct;
        }

        private bool ShoppingListProductExists(int id)
        {
            return _context.ShoppingListProduct.Any(e => e.ShoppingListProductId == id);
        }
    }
}
