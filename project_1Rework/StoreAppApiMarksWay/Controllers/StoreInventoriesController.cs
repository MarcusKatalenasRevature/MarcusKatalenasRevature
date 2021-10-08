using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreAppApiDbContext.Models;
using StoreWebApi;

namespace StoreWebApi.Controllers
{
    [Route("api/StoreInverntories")]
    [ApiController]
    public class StoreInventoriesController : ControllerBase
    {
        private readonly Project_1StoreAppDBContext _context;

        public StoreInventoriesController(Project_1StoreAppDBContext context)
        {
            _context = context;
        }

        // GET: api/StoreInventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreInventory>>> GetStoreInventories()
        {
            return await _context.StoreInventories.ToListAsync();
        }

        // GET: api/StoreInventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreInventory>> GetStoreInventory(int id)
        {
            var storeInventory = await _context.StoreInventories.FindAsync(id);

            if (storeInventory == null)
            {
                return NotFound();
            }

            return storeInventory;
        }

        // PUT: api/StoreInventories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStoreInventory(int id, StoreInventory storeInventory)
        {
            if (id != storeInventory.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(storeInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreInventoryExists(id))
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

        // POST: api/StoreInventories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StoreInventory>> PostStoreInventory(StoreInventory storeInventory)
        {
            _context.StoreInventories.Add(storeInventory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StoreInventoryExists(storeInventory.ProductId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStoreInventory", new { id = storeInventory.ProductId }, storeInventory);
        }

        // DELETE: api/StoreInventories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoreInventory(int id)
        {
            var storeInventory = await _context.StoreInventories.FindAsync(id);
            if (storeInventory == null)
            {
                return NotFound();
            }

            _context.StoreInventories.Remove(storeInventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoreInventoryExists(int id)
        {
            return _context.StoreInventories.Any(e => e.ProductId == id);
        }
    }
}
