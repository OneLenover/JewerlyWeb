using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace JewelryWeb.Controllers
{
    /// <summary>
    /// Контроллер для управления платежами
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsService _paymentsService;

        /// <summary>
        /// Конструктор контроллера платежей
        /// </summary>
        /// <param name="paymentsService">Сервис платежей</param>
        public PaymentsController(IPaymentsService paymentsService)
        {
            _paymentsService = paymentsService;
        }

        /// <summary>
        /// Получает список всех платежей
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех платежей</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments(CancellationToken cancellationToken)
        {
            var payments = await _paymentsService.GetAllPaymentsAsync(cancellationToken);
            return Ok(payments);
        }

        /// <summary>
        /// Получает платеж по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор платежа</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект платежа</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id, CancellationToken cancellationToken)
        {
            var payment = await _paymentsService.GetPaymentByIdAsync(id, cancellationToken);
            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        /// <summary>
        /// Обновляет платеж
        /// </summary>
        /// <param name="id">Идентификатор обновляемого платежа</param>
        /// <param name="payment">Объект с новыми данными платежа</param>
        /// <returns>Результат обновления</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, Payment payment)
        {
            var update = await _paymentsService.UpdatePaymentAsync(id, payment);
            if (!update)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Создает новый платеж
        /// </summary>
        /// <param name="payment">Объект платежа для создания</param>
        /// <returns>Созданный объект платежа</returns>
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            var createdPayment = await _paymentsService.CreatePaymentAsync(payment);
            return CreatedAtAction(nameof(GetPayment), new { id = createdPayment.Id }, createdPayment);
        }

        /// <summary>
        /// Удаляет платеж по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемого платежа</param>
        /// <returns>Результат удаления</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var deleted = await _paymentsService.DeletePaymentAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}