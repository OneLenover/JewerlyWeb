using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;

namespace JewelryWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderElementsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderElementsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderElements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderElements>>> GetOrdersElements()
        {
            return await _context.OrdersElements.ToListAsync();
        }

        // GET: api/OrderElements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderElements>> GetOrderElements(int id)
        {
            var orderElements = await _context.OrdersElements.FindAsync(id);

            if (orderElements == null)
            {
                return NotFound();
            }

            return orderElements;
        }

        // PUT: api/OrderElements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderElements(int id, OrderElements orderElements)
        {
            if (id != orderElements.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderElements).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderElementsExists(id))
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

        // POST: api/OrderElements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderElements>> PostOrderElements(OrderElements orderElements)
        {
            _context.OrdersElements.Add(orderElements);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderElements", new { id = orderElements.Id }, orderElements);
        }

        // DELETE: api/OrderElements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderElements(int id)
        {
            var orderElements = await _context.OrdersElements.FindAsync(id);
            if (orderElements == null)
            {
                return NotFound();
            }

            _context.OrdersElements.Remove(orderElements);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderElementsExists(int id)
        {
            return _context.OrdersElements.Any(e => e.Id == id);
        }
    }
}
