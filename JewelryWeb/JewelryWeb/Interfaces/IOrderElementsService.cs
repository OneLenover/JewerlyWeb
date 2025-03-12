using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с элементами заказа
    /// </summary>
    public interface IOrderElementsService
    {
        /// <summary>
        /// Получает список всех элементов заказа
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех элементов заказа</returns>
        Task<IEnumerable<OrderElements>> GetAllOrderElementsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает элемент заказа по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор элемента заказа</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект элемента заказа</returns>
        Task<OrderElements> GetOrderElementByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет элемент заказа
        /// </summary>
        /// <param name="id">Идентификатор обновляемого элемента заказа</param>
        /// <param name="orderElement">Объект с новыми данными элемента заказа</param>
        /// <returns>true - успешно, false - ошибка</returns>
        Task<bool> UpdateOrderElementAsync(int id, OrderElements orderElement);

        /// <summary>
        /// Создает новый элемент заказа
        /// </summary>
        /// <param name="orderElement">Объект элемента заказа для создания</param>
        /// <returns>Созданный объект элемента заказа</returns>
        Task<OrderElements> CreateOrderElementAsync(OrderElements orderElement);

        /// <summary>
        /// Удаляет элемент заказа по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемого элемента заказа</param>
        /// <returns>true - успешно, false - ошибка</returns>
        Task<bool> DeleteOrderElementAsync(int id);
    }
}