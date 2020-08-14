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
    [Route("api/MainStore")]
    [ApiController]
    public class MainStoresController : ControllerBase
    {
        private readonly MyShopperContext _context;

        public MainStoresController(MyShopperContext context)
        {
            _context = context;
        }

        // GET: api/MainStores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MainStore>>> GetMainStore()
        {
            return await _context.MainStore.ToListAsync();
        }

        // GET: api/MainStores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MainStore>> GetMainStore(int id)
        {
            var mainStore = await _context.MainStore.FindAsync(id);

            if (mainStore == null)
            {
                return NotFound();
            }

            return mainStore;
        }

        // PUT: api/MainStores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMainStore(int id, MainStore mainStore)
        {
            if (id != mainStore.MainStoreId)
            {
                return BadRequest();
            }

            _context.Entry(mainStore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainStoreExists(id))
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

        // POST: api/MainStores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MainStore>> PostMainStore(MainStore mainStore)
        {
            _context.MainStore.Add(mainStore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMainStore", new { id = mainStore.MainStoreId }, mainStore);
        }

        // DELETE: api/MainStores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MainStore>> DeleteMainStore(int id)
        {
            var mainStore = await _context.MainStore.FindAsync(id);
            if (mainStore == null)
            {
                return NotFound();
            }

            _context.MainStore.Remove(mainStore);
            await _context.SaveChangesAsync();

            return mainStore;
        }

        private bool MainStoreExists(int id)
        {
            return _context.MainStore.Any(e => e.MainStoreId == id);
        }
    }
}
