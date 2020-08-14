using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShopperAPI.Models;
using MyShopperAPI.Wrappers;

namespace MyShopperAPI.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyShopperContext _context;

        public ProductsController(MyShopperContext context)
        {
            _context = context;
        }

        // GET: api/Products
        //[HttpGet("{page}/{pageSize}")]
        //public async Task<ActionResult<IEnumerable<Product>>> GetProduct(int page , int pageSize)
        //{
        //    var PagedData = await _context.Product
        //                    .Skip((page - 1) * pageSize)
        //                    .Take(pageSize)
        //                    .ToListAsync();
        //    var TotalRecords = await _context.Product.CountAsync();

        //    return PagedData;

        //}

        [HttpGet]
        public async Task<IActionResult> GetProduct([FromQuery] PaginationFilter filter)
        {
            
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _context.Product
                           .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                           .Take(validFilter.PageSize)
                           .ToListAsync();
            var TotalRecords = await _context.Product.CountAsync();
            var TotalPages = Convert.ToInt32(Math.Ceiling(((double)TotalRecords / (double)validFilter.PageSize)));
            var Response = new PagedResponse<List<Product>>(pagedData, validFilter.PageNumber, validFilter.PageSize);

            Response.TotalRecords = TotalRecords;
            Response.TotalPages = TotalPages;

            return Ok(Response);

        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchProduct([FromQuery] String Search , [FromQuery] PaginationFilter filter)
        {

            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _context.Product.Where(p => p.ProductName.ToLower().StartsWith(Search))
                           .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                           .Take(validFilter.PageSize)
                           .ToListAsync();
            //var TotalRecords = await _context.Product.CountAsync();
            var TotalRecords = await _context.Product.Where(p => p.ProductName.ToLower().StartsWith(Search))
                               .CountAsync();
            var TotalPages = Convert.ToInt32(Math.Ceiling(((double)TotalRecords / (double)validFilter.PageSize)));
            var Response = new PagedResponse<List<Product>>(pagedData, validFilter.PageNumber, validFilter.PageSize);

            Response.TotalRecords = TotalRecords;
            Response.TotalPages = TotalPages;

            return Ok(Response);
        }

        //[HttpGet("ShoppingListProduct/{id}")]
        //public async Task<ActionResult<IEnumerable<Product>>> GetShoppingListProducts(int id)
        //{

        //    var shoppingList = await _context.ShoppingListProduct.Include(slp => slp.Product).Where(slp => slp.ShoppingListId == id).ToListAsync();
        //    var Products = new List<Product>();

        //    foreach (var shoppingListProduct in shoppingList)
        //    {
        //        Products.Add(shoppingListProduct.Product);
        //    }

        //    return Products;

        //}

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            var CurrentProduct = await _context.Product.FindAsync(id);

            if (CurrentProduct.CurrentPrice != product.CurrentPrice)
            {

                var newPriceHistory = new PriceHistory();
                newPriceHistory.ProductId = product.ProductId;
                newPriceHistory.DateFrom = product.PriceCreationDate;
                newPriceHistory.DateTo = DateTime.Now;
                newPriceHistory.Price = CurrentProduct.CurrentPrice;
                _context.PriceHistory.Add(newPriceHistory);
                await _context.SaveChangesAsync();

            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {

            product.PriceCreationDate = DateTime.Now;

            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
