using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace JewelryWeb.Controllers
{
    /// <summary>
    /// Контроллер для управления отзывами
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        /// <summary>
        /// Конструктор контроллера отзывов
        /// </summary>
        /// <param name="reviewService">Сервис отзывов</param>
        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        /// <summary>
        /// Получает список всех отзывов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех отзывов</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews(CancellationToken cancellationToken)
        {
            var reviews = await _reviewService.GetAllReviewsAsync(cancellationToken);
            return Ok(reviews);
        }

        /// <summary>
        /// Получает отзыв по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор отзыва</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект отзыва</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id, CancellationToken cancellationToken)
        {
            var review = await _reviewService.GetReviewByIdAsync(id, cancellationToken);
            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        /// <summary>
        /// Обновляет отзыв
        /// </summary>
        /// <param name="id">Идентификатор обновляемого отзыва</param>
        /// <param name="review">Объект с новыми данными отзыва</param>
        /// <returns>Результат обновления</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, Review review)
        {
            var updated = await _reviewService.UpdateReviewAsync(id, review);
            if (!updated)
            {
                return BadRequest();
            }

            return NoContent();
        }

        /// <summary>
        /// Создает новый отзыв
        /// </summary>
        /// <param name="review">Объект отзыва для создания</param>
        /// <returns>Созданный объект отзыва</returns>
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            var createdReview = await _reviewService.CreateReviewAsync(review);
            return CreatedAtAction(nameof(GetReview), new { id = createdReview.Id }, createdReview);
        }

        /// <summary>
        /// Удаляет отзыв по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемого отзыва</param>
        /// <returns>Результат удаления</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var deleted = await _reviewService.DeleteReviewAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}