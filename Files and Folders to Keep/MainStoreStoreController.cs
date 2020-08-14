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
    [Route("api/MainStoreStore")]
    [ApiController]
    public class MainStoreStoreController : ControllerBase
    {
        private readonly MyShopperContext _context;

        public MainStoreStoreController(MyShopperContext context)
        {
            _context = context;
        }

        // GET: api/MainStoreStore
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MainStoreStore>>> GetMainStoreStore()
        {
            return await _context.MainStoreStore.ToListAsync();
        }

        // GET: api/MainStoreStore/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MainStoreStore>>> GetMainStoreStore(int id)
        {
            var mainStoreStore = await _context.MainStoreStore.Include(mss => mss.Store).Where(mss => mss.MainStoreId == id).ToListAsync();

            if (mainStoreStore == null)
            {
                return NotFound();
            }

            return mainStoreStore;
        }

        // PUT: api/MainStoreStore/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMainStoreStore(MainStoreStore mainStoreStore , int id)
        {
            //if (id != mainStoreStore.MainStoreStoreId)
            //{
            //    return BadRequest();
            //}

            //id is the Current Main Store ID and the MainStoreID in the object Parameter is the new one.

            var ChangerObject = _context.MainStoreStore.Where(mss => mss.MainStoreId == id && 
            mss.StoreId == mainStoreStore.StoreId).FirstOrDefault();
            ChangerObject.MainStoreId = mainStoreStore.MainStoreId;

            _context.Entry(ChangerObject).State = EntityState.Modified;

            //try
            //{
                await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            ///{
            //if (!MainStoreStoreExists(id))
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    throw;
            //}

            //throw;
            //}
            return CreatedAtAction("GetMainStoreStore", new { id = ChangerObject.MainStoreStoreId }, ChangerObject);
            //return NoContent();
        }

        // POST: api/MainStoreStore
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MainStoreStore>> PostMainStoreStore(MainStoreStore mainStoreStore)
        {
            _context.MainStoreStore.Add(mainStoreStore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMainStoreStore", new { id = mainStoreStore.MainStoreStoreId }, mainStoreStore);
        }

        // DELETE: api/MainStoreStore/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MainStoreStore>> DeleteMainStoreStore(int id)
        {
            var mainStoreStore = await _context.MainStoreStore.FindAsync(id);
            if (mainStoreStore == null)
            {
                return NotFound();
            }

            _context.MainStoreStore.Remove(mainStoreStore);
            await _context.SaveChangesAsync();

            return mainStoreStore;
        }

        private bool MainStoreStoreExists(int id)
        {
            return _context.MainStoreStore.Any(e => e.MainStoreStoreId == id);
        }
    }
}
