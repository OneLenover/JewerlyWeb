using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace JewelryWeb.Controllers
{
    /// <summary>
    /// Контроллер для управления материалами
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        /// <summary>
        /// Конструктор контроллера материалов
        /// </summary>
        /// <param name="materialService">Сервис материалов</param>
        public MaterialsController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        /// <summary>
        /// Получает список всех материалов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех материалов</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material>>> GetMaterials(CancellationToken cancellationToken)
        {
            var materials = await _materialService.GetAllMaterialsAsync(cancellationToken);
            return Ok(materials);
        }

        /// <summary>
        /// Получает материал по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор материала</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект материала</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterial(int id, CancellationToken cancellationToken)
        {
            var material = await _materialService.GetMaterialByIdAsync(id, cancellationToken);
            if (material == null)
            {
                return NotFound();
            }

            return Ok(material);
        }

        /// <summary>
        /// Обновляет материал
        /// </summary>
        /// <param name="id">Идентификатор обновляемого материала</param>
        /// <param name="material">Объект с новыми данными материала</param>
        /// <returns>Результат обновления</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(int id, Material material)
        {
            var updated = await _materialService.UpdateMaterialAsync(id, material);
            if (!updated)
            {
                return BadRequest();
            }

            return NoContent();
        }

        /// <summary>
        /// Создает новый материал
        /// </summary>
        /// <param name="material">Объект материала для создания</param>
        /// <returns>Созданный объект материала</returns>
        [HttpPost]
        public async Task<ActionResult<Material>> PostMaterial(Material material)
        {
            var createdMaterial = await _materialService.CreateMaterialAsync(material);
            return CreatedAtAction(nameof(GetMaterial), new { id = createdMaterial.Id }, createdMaterial);
        }

        /// <summary>
        /// Удаляет материал по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемого материала</param>
        /// <returns>Результат удаления</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            var deleted = await _materialService.DeleteMaterialAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}