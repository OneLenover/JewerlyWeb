using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;
using System.Threading;

namespace JewelryWeb.Services
{
    /// <summary>
    /// Сервис для работы с платежами
    /// </summary>
    public class PaymentsService : IPaymentsService
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Конструктор сервиса категорий
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public PaymentsService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получается список всех платежей
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync(CancellationToken cancellationToken)
        {
            return await _context.Payments.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Получает платеж по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор платежа</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект платежа</returns>
        public async Task<Payment> GetPaymentByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Payments.FindAsync(id, cancellationToken);
        }

        /// <summary>
        /// Обновляет данные платежа
        /// </summary>
        /// <param name="id">Идентификатор платежа</param>
        /// <param name="payment">Обновленный объект платежа</param>
        /// <returns>true - успешно, false - ошибка</returns>
        public async Task<bool> UpdatePaymentAsync(int id, Payment payment)
        {
            if (id != payment.Id)
            {
                return false;
            }

            _context.Entry(payment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Создает новый платеж
        /// </summary>
        /// <param name="payment">Объект платежа</param>
        /// <returns>Созданный платеж</returns>
        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        /// <summary>
        /// Удаляется платеж по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор платежа</param>
        /// <returns>true - успешно, false - ошибка</returns>
        public async Task<bool> DeletePaymentAsync(int id)
        {
            var payment = new Payment { Id = id };
            _context.Payments.Attach(payment);
            _context.Payments.Remove(payment);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}