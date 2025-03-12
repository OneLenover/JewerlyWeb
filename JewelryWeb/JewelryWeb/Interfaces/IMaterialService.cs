using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с материалами
    /// </summary>
    public interface IMaterialService
    {
        /// <summary>
        /// Получает список всех материалов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех материалов</returns>
        Task<IEnumerable<Material>> GetAllMaterialsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает материал по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор материала</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект материала</returns>
        Task<Material> GetMaterialByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет материал
        /// </summary>
        /// <param name="id">Идентификатор обновляемого материала</param>
        /// <param name="material">Объект с новыми данными материала</param>
        /// <returns>true - успешно, false - ошибка</returns>
        Task<bool> UpdateMaterialAsync(int id, Material material);

        /// <summary>
        /// Создает новый материал
        /// </summary>
        /// <param name="material">Объект материала для создания</param>
        /// <returns>Созданный объект материала</returns>
        Task<Material> CreateMaterialAsync(Material material);

        /// <summary>
        /// Удаляет материал по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемого материала</param>
        /// <returns>true - успешно, false - ошибка</returns>
        Task<bool> DeleteMaterialAsync(int id);
    }
}