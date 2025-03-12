using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с категориями
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Получает список всех категорий
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список категорий</returns>
        Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получается категорию по id
        /// </summary>
        /// <param name="id">Уникальный идентификатор категории</param>
        /// <param name="cancellation">Токен отмены категории</param>
        /// <returns>Объект категории</returns>
        Task<Category> GetCategoryByIdAsync(int id, CancellationToken cancellation);

        /// <summary>
        /// Обновляет категории
        /// </summary>
        /// <param name="id">Идентификатор обновляемой категории</param>
        /// <param name="category">Объект с новыми данными</param>
        /// <returns>true - успешно, false - ошибка</returns>
        Task<bool> UpdateCategoryAsync(int id, Category category);

        /// <summary>
        /// Создает новую категорию
        /// </summary>
        /// <param name="category">Объект категории для создания</param>
        /// <returns>Созданный объект категории</returns>
        Task<Category> CreateCategoryAsync(Category category);

        /// <summary>
        /// Удаляет категорию по id
        /// </summary>
        /// <param name="id">Идентификатор удаляемой категории</param>
        /// <returns>true - успешно, false - ошибка</returns>
        Task<bool> DeleteCategoryAsync(int id);
    }
}