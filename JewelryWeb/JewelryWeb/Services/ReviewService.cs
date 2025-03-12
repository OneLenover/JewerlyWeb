using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;

namespace JewelryWeb.Services
{
    /// <summary>
    /// Сервис для управления отзывами
    /// </summary>
    public class ReviewService : IReviewService
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Конструктор сервиса категорий
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public ReviewService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает список всех отзывов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех отзывов</returns>
        public async Task<IEnumerable<Review>> GetAllReviewsAsync(CancellationToken cancellationToken)
        {
            return await _context.Reviews.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Получает отзыв по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор отзыва</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект отзыва</returns>
        public async Task<Review> GetReviewByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Reviews.FindAsync(id, cancellationToken);
        }

        /// <summary>
        /// Обновляет отзыв
        /// </summary>
        /// <param name="id">Идентификатор обновляемого отзыва</param>
        /// <param name="review">Объект с новыми данными отзыва</param>
        /// <returns>true - успешно, false - ошибка</returns>
        public async Task<bool> UpdateReviewAsync(int id, Review review)
        {
            if (id != review.Id)
            {
                return false;
            }

            _context.Entry(review).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Создает новый отзыв
        /// </summary>
        /// <param name="review">Объект отзыва для создания</param>
        /// <returns>Созданный объект отзыва</returns>
        public async Task<Review> CreateReviewAsync(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        /// <summary>
        /// Удаляет отзыв по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемого отзыва</param>
        /// <returns>true - успешно, false - ошибка</returns>
        public async Task<bool> DeleteReviewAsync(int id)
        {
            var review = new Review { Id = id };
            _context.Reviews.Attach(review);
            _context.Reviews.Remove(review);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
