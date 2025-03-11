using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;

namespace JewelryWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderElementsController : ControllerBase
    {
        private readonly IOrderElementsService _orderElementsService;

        public OrderElementsController(IOrderElementsService orderElementsService)
        {
            _orderElementsService = orderElementsService;
        }

        // GET: api/OrderElements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderElements>>> GetOrdersElements(CancellationToken cancellationToken)
        {
            var orderElements = await _orderElementsService.GetAllOrderElementsAsync(cancellationToken);
            return Ok(orderElements);
        }

        // GET: api/OrderElements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderElements>> GetOrderElements(int id, CancellationToken cancellationToken)
        {
            var orderElement = await _orderElementsService.GetOrderElementByIdAsync(id, cancellationToken);
            if (orderElement == null)
            {
                return NotFound();
            }

            return Ok(orderElement);
        }

        // PUT: api/OrderElements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderElements(int id, OrderElements orderElements)
        {
            var update = await _orderElementsService.UpdateOrderElementAsync(id, orderElements);
            if (!update)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/OrderElements
        [HttpPost]
        public async Task<ActionResult<OrderElements>> PostOrderElements(OrderElements orderElements)
        {
            var createdOrderElement = await _orderElementsService.CreateOrderElementAsync(orderElements);
            return CreatedAtAction(nameof(GetOrderElements), new { id = createdOrderElement.Id }, createdOrderElement);
        }

        // DELETE: api/OrderElements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderElements(int id)
        {
            var deleted = await _orderElementsService.DeleteOrderElementAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}