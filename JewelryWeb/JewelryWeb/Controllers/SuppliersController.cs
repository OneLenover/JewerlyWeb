using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace JewelryWeb.Controllers
{
    /// <summary>
    /// Контроллер для управления поставщиками
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        /// <summary>
        /// Конструктор контроллера поставщиков
        /// </summary>
        /// <param name="supplierService">Сервис поставщиков</param>
        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        /// <summary>
        /// Получает список всех поставщиков
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех поставщиков</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers(CancellationToken cancellationToken)
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync(cancellationToken);
            return Ok(suppliers);
        }

        /// <summary>
        /// Получает поставщика по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор поставщика</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект поставщика</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id, CancellationToken cancellationToken)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id, cancellationToken);

            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(supplier);
        }

        /// <summary>
        /// Обновляет поставщика
        /// </summary>
        /// <param name="id">Идентификатор обновляемого поставщика</param>
        /// <param name="supplier">Объект с новыми данными поставщика</param>
        /// <returns>Результат обновления</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(int id, Supplier supplier)
        {
            var update = await _supplierService.UpdateSupplierAsync(id, supplier);
            if (!update)
            {
                return BadRequest();
            }

            return NoContent();
        }

        /// <summary>
        /// Создает нового поставщика
        /// </summary>
        /// <param name="supplier">Объект поставщика для создания</param>
        /// <returns>Созданный объект поставщика</returns>
        [HttpPost]
        public async Task<ActionResult<Supplier>> PostSupplier(Supplier supplier)
        {
            var createdSupplier = await _supplierService.CreateSupplierAsync(supplier);
            return CreatedAtAction(nameof(GetSupplier), new { id = createdSupplier.Id }, createdSupplier);
        }

        /// <summary>
        /// Удаляет поставщика по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемого поставщика</param>
        /// <returns>Результат удаления</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var deleted = await _supplierService.DeleteSupplierAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}