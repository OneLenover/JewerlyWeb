using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с заказами
    /// </summary>
    public interface IOrdersService
    {
        /// <summary>
        /// Получает список всех заказов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех заказов</returns>
        Task<IEnumerable<Order>> GetAllOrdersAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает заказ по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор заказа</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект заказа</returns>
        Task<Order> GetOrderByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет заказ
        /// </summary>
        /// <param name="id">Идентификатор обновляемого заказа</param>
        /// <param name="order">Объект с новыми данными заказа</param>
        /// <returns>true - успешно, false - ошибка</returns>
        Task<bool> UpdateOrderAsync(int id, Order order);

        /// <summary>
        /// Создает новый заказ
        /// </summary>
        /// <param name="order">Объект заказа для создания</param>
        /// <returns>Созданный объект заказа</returns>
        Task<Order> CreateOrderAsync(Order order);

        /// <summary>
        /// Удаляет заказ по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемого заказа</param>
        /// <returns>true - успешно, false - ошибка</returns>
        Task<bool> DeleteOrderAsync(int id);
    }
}