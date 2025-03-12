using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с платежами
    /// </summary>
    public interface IPaymentsService
    {
        /// <summary>
        /// Получает список всех платежей
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех платежей</returns>
        Task<IEnumerable<Payment>> GetAllPaymentsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает платеж по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор платежа</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект платежа</returns>
        Task<Payment> GetPaymentByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет платеж
        /// </summary>
        /// <param name="id">Идентификатор обновляемого платежа</param>
        /// <param name="payment">Объект с новыми данными платежа</param>
        /// <returns>true - успешно, false - ошибка</returns>
        Task<bool> UpdatePaymentAsync(int id, Payment payment);

        /// <summary>
        /// Создает новый платеж
        /// </summary>
        /// <param name="payment">Объект платежа для создания</param>
        /// <returns>Созданный объект платежа</returns>
        Task<Payment> CreatePaymentAsync(Payment payment);

        /// <summary>
        /// Удаляет платеж по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемого платежа</param>
        /// <returns>true - успешно, false - ошибка</returns>
        Task<bool> DeletePaymentAsync(int id);
    }
}