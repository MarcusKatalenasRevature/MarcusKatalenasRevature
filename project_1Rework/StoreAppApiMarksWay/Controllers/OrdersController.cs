using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.ViewModels;
using StoreAppApiDbContext.Models;
using StoreWebApi;

namespace StoreWebApi.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly Project_1StoreAppDBContext _context;

        private readonly IOrderRepo _orepo;

        public OrdersController(Project_1StoreAppDBContext context, IOrderRepo or)
        {
            _context = context;
            _orepo = or;
        }
        
        [HttpGet("findOrderListSID/{storeID}")]
        public async Task<ActionResult<ViewModelOrder>> findOrderListSID(int storeID)
        {
            //  if (!ModelState.IsValid) return BadRequest();

            ViewModelOrder o = new ViewModelOrder() { StoreId = storeID};
            //send fname and lname into a method of the business layer to check the Db fo that guy/gal;
            List<Order> o1 = await _orepo.OrderListByStoreIDAsync(o);
            if (o1 == null)
            {
                return NotFound();
            }

            return Ok(o1);
        }
        

        
        [HttpGet("findOrderListCID/{customerID}")]
        public async Task<ActionResult<ViewModelOrder>> findOrderListCID(int customerID)
        {
            //  if (!ModelState.IsValid) return BadRequest();

            ViewModelOrder o = new ViewModelOrder() { CustomerId = customerID };
            //send fname and lname into a method of the business layer to check the Db fo that guy/gal;
            List<Order> o1 = await _orepo.OrderListByCustomerIDAsync(o);
            if (o1 == null)
            {
                return NotFound();
            }

            return Ok(o1);
        }
        

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            ViewModelOrder vom = new ViewModelOrder() { StoreId = order.StoreId, CustomerId = order.CustomerId };

            await _orepo.InsertOrderAsync(vom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
