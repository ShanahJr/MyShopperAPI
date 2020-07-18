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
    [Route("api/ShoppingListStores")]
    [ApiController]
    public class ShoppingListStoresController : ControllerBase
    {
        private readonly MyShopperContext _context;

        public ShoppingListStoresController(MyShopperContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingListStores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingListStore>>> GetShoppingListStore()
        {
            return await _context.ShoppingListStore.ToListAsync();
        }

        // GET: api/ShoppingListStores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingListStore>> GetShoppingListStore(int id)
        {
            var shoppingListStore = await _context.ShoppingListStore.FindAsync(id);

            if (shoppingListStore == null)
            {
                return NotFound();
            }

            return shoppingListStore;
        }

        // PUT: api/ShoppingListStores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingListStore(int id, ShoppingListStore shoppingListStore)
        {
            if (id != shoppingListStore.ShoppingListStoreId)
            {
                return BadRequest();
            }

            _context.Entry(shoppingListStore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingListStoreExists(id))
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

        // POST: api/ShoppingListStores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShoppingListStore>> PostShoppingListStore(ShoppingListStore shoppingListStore)
        {
            _context.ShoppingListStore.Add(shoppingListStore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingListStore", new { id = shoppingListStore.ShoppingListStoreId }, shoppingListStore);
        }

        // DELETE: api/ShoppingListStores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShoppingListStore>> DeleteShoppingListStore(int id)
        {
            var shoppingListStore = await _context.ShoppingListStore.FindAsync(id);
            if (shoppingListStore == null)
            {
                return NotFound();
            }

            _context.ShoppingListStore.Remove(shoppingListStore);
            await _context.SaveChangesAsync();

            return shoppingListStore;
        }

        private bool ShoppingListStoreExists(int id)
        {
            return _context.ShoppingListStore.Any(e => e.ShoppingListStoreId == id);
        }
    }
}
