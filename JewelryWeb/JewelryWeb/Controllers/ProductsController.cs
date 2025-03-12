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
    /// Контроллер для управления товарами
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        /// <summary>
        /// Конструктор контроллера товаров
        /// </summary>
        /// <param name="productsService">Сервис товаров</param>
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        /// <summary>
        /// Получает список всех товаров
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех товаров</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(CancellationToken cancellationToken)
        {
            var products = await _productsService.GetAllProductsAsync(cancellationToken);
            return Ok(products);
        }

        /// <summary>
        /// Получает товар по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор товара</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект товара</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id, CancellationToken cancellationToken)
        {
            var product = await _productsService.GetProductByIdAsync(id, cancellationToken);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        /// <summary>
        /// Обновляет товар
        /// </summary>
        /// <param name="id">Идентификатор обновляемого товара</param>
        /// <param name="product">Объект с новыми данными товара</param>
        /// <returns>Результат обновления</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            var update = await _productsService.UpdateProductAsync(id, product);
            if (!update)
            {
                return BadRequest();
            }

            return NoContent();
        }

        /// <summary>
        /// Создает новый товар
        /// </summary>
        /// <param name="product">Объект товара для создания</param>
        /// <returns>Созданный объект товара</returns>
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var createdProduct = await _productsService.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);
        }

        /// <summary>
        /// Удаляет товар по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемого товара</param>
        /// <returns>Результат удаления</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _productsService.DeleteProductAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}