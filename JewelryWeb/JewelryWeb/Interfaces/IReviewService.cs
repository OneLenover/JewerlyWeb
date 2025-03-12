using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с отзывами
    /// </summary>
    public interface IReviewService
    {
        /// <summary>
        /// Получает список всех отзывов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех отзывов</returns>
        Task<IEnumerable<Review>> GetAllReviewsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает отзыв по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор отзыва</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект отзыва</returns>
        Task<Review> GetReviewByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет отзыв
        /// </summary>
        /// <param name="id">Идентификатор обновляемого отзыва</param>
        /// <param name="review">Объект с новыми данными отзыва</param>
        /// <returns>true - успешно, false - ошибка</returns>
        Task<bool> UpdateReviewAsync(int id, Review review);

        /// <summary>
        /// Создает новый отзыв
        /// </summary>
        /// <param name="review">Объект отзыва для создания</param>
        /// <returns>Созданный объект отзыва</returns>
        Task<Review> CreateReviewAsync(Review review);

        /// <summary>
        /// Удаляет отзыв по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемого отзыва</param>
        /// <returns>true - успешно, false - ошибка</returns>
        Task<bool> DeleteReviewAsync(int id);
    }
}