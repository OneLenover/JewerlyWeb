using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;
using System.Threading;

namespace JewelryWeb.Services
{
    /// <summary>
    /// Сервис для работы с материалами
    /// </summary>
    public class MaterialService : IMaterialService
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Конструктор сервиса категорий
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public MaterialService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает список всех материалов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех материалов</returns>
        public async Task<IEnumerable<Material>> GetAllMaterialsAsync(CancellationToken cancellationToken)
        {
            return await _context.Materials.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Получает материал по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор материала</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект материала</returns>
        public async Task<Material> GetMaterialByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Materials.FindAsync(id, cancellationToken);
        }

        /// <summary>
        /// Обновляет данные материала
        /// </summary>
        /// <param name="id">Идентификатор материала</param>
        /// <param name="material">Объект с новыми данными материала</param>
        /// <returns>true - успешно, false - ошибка</returns>
        public async Task<bool> UpdateMaterialAsync(int id, Material material)
        {
            if (id != material.Id)
            {
                return false;
            }

            _context.Entry(material).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Создает новый материал
        /// </summary>
        /// <param name="material">Объект материала для создания</param>
        /// <returns>Созданный объект материала</returns>
        public async Task<Material> CreateMaterialAsync(Material material)
        {
            _context.Materials.Add(material);
            await _context.SaveChangesAsync();
            return material;
        }

        /// <summary>
        /// Удаляет материал по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор материала</param>
        /// <returns>true - успешно, false - ошибка</returns>
        public async Task<bool> DeleteMaterialAsync(int id)
        {
            var material = new Material { Id = id };
            _context.Materials.Attach(material);
            _context.Materials.Remove(material);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}