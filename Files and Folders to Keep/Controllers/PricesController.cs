﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShopperAPI.Models;

namespace MyShopperAPI.Controllers
{
    [Route("api/Prices")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly MyShopperContext _context;

        public PricesController(MyShopperContext context)
        {
            _context = context;
        }

        // GET: api/Prices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Price>>> GetPrice()
        {
            return await _context.Price.ToListAsync();
        }

        // GET: api/Prices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Price>> GetPrice(int id)
        {
            var price = await _context.Price.FindAsync(id);

            if (price == null)
            {
                return NotFound();
            }

            return price;
        }

        // PUT: api/Prices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrice(int id, Price price)
        {
            if (id != price.PriceId)
            {
                return BadRequest();
            }

            _context.Entry(price).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceExists(id))
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

        // POST: api/Prices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Price>> PostPrice(Price price)
        {
            _context.Price.Add(price);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrice", new { id = price.PriceId }, price);
        }

        // DELETE: api/Prices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Price>> DeletePrice(int id)
        {
            var price = await _context.Price.FindAsync(id);
            if (price == null)
            {
                return NotFound();
            }

            _context.Price.Remove(price);
            await _context.SaveChangesAsync();

            return price;
        }

        private bool PriceExists(int id)
        {
            return _context.Price.Any(e => e.PriceId == id);
        }
    }
}
