using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace JewelryWeb.Controllers
{
    /// <summary>
    /// Контроллер для управления закупками
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        /// <summary>
        /// Конструктор контроллера закупок
        /// </summary>
        /// <param name="purchaseService">Сервис закупок</param>
        public PurchasesController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        /// <summary>
        /// Получает список всех закупок
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех закупок</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchases(CancellationToken cancellationToken)
        {
            var purchases = await _purchaseService.GetAllPurchasesAsync(cancellationToken);
            return Ok(purchases);
        }

        /// <summary>
        /// Получает закупку по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор закупки</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект закупки</returns>
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

        /// <summary>
        /// Обновляет закупку
        /// </summary>
        /// <param name="id">Идентификатор обновляемой закупки</param>
        /// <param name="purchase">Объект с новыми данными закупки</param>
        /// <returns>Результат обновления</returns>
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

        /// <summary>
        /// Создает новую закупку
        /// </summary>
        /// <param name="purchase">Объект закупки для создания</param>
        /// <returns>Созданный объект закупки</returns>
        [HttpPost]
        public async Task<ActionResult<Purchase>> PostPurchase(Purchase purchase)
        {
            var createdPurchase = await _purchaseService.CreatePurchaseAsync(purchase);
            return CreatedAtAction(nameof(GetPurchase), new { id = createdPurchase.Id }, createdPurchase);
        }

        /// <summary>
        /// Удаляет закупку по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемой закупки</param>
        /// <returns>Результат удаления</returns>
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