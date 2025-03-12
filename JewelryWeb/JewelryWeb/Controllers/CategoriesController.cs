using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace JewelryWeb.Controllers
{
    /// <summary>
    /// Контроллер для управления категориями товаров
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        /// <summary>
        /// Конструктор контроллера категорий
        /// </summary>
        /// <param name="categoryService">Сервис категорий</param>
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Получает список всех категорий
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список категорий</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories(CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetAllCategoriesAsync(cancellationToken);
            return Ok(categories);
        }

        /// <summary>
        /// Получает категорию по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор категории</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект категории</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id, cancellationToken);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        /// <summary>
        /// Обновляет категорию
        /// </summary>
        /// <param name="id">Идентификатор категории</param>
        /// <param name="category">Объект с обновленными данными</param>
        /// <returns>Результат операции</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            var updated = await _categoryService.UpdateCategoryAsync(id, category);
            if (!updated)
            {
                return BadRequest();
            }

            return NoContent();
        }

        /// <summary>
        /// Создает новую категорию
        /// </summary>
        /// <param name="category">Объект категории</param>
        /// <returns>Созданная категория</returns>
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            var createdCategory = await _categoryService.CreateCategoryAsync(category);
            return CreatedAtAction(nameof(GetCategory), new { id = createdCategory.Id }, createdCategory);
        }

        /// <summary>
        /// Удаляет категорию по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор категории</param>
        /// <returns>Результат удаления</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var deleted = await _categoryService.DeleteCategoryAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
