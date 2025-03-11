using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;

namespace JewelryWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchasesController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        // GET: api/Purchases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchases(CancellationToken cancellation)
        {
            var purchases = await _purchaseService.GetAllPurchasesAsync(cancellation);
            return Ok(purchases);
        }

        // GET: api/Purchases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Purchase>> GetPurchase(int id, CancellationToken cancellationToken)
        {
            var purchase = await _purchaseService.GetPurchaseByIdAsync(id, cancellationToken);
            if (purchase == null)
            {
                return NotFound();
            }

            return Ok(purchase);
        }

        // PUT: api/Purchases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchase(int id, Purchase purchase)
        {
            var updated = await _purchaseService.UpdatePurchaseAsync(id, purchase);
            if (!updated)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/Purchases
        [HttpPost]
        public async Task<ActionResult<Purchase>> PostPurchase(Purchase purchase)
        {
            var createdPurchase = await _purchaseService.CreatePurchaseAsync(purchase);
            return CreatedAtAction(nameof(GetPurchase), new { id = createdPurchase.Id }, createdPurchase);
        }

        // DELETE: api/Purchases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            var deleted = await _purchaseService.DeletePurchaseAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}