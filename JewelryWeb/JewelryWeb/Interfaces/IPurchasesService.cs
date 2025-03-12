using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с закупками
    /// </summary>
    public interface IPurchaseService
    {
        /// <summary>
        /// Получает список всех закупок
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех закупок</returns>
        Task<IEnumerable<Purchase>> GetAllPurchasesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает закупку по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор закупки</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект закупки</returns>
        Task<Purchase> GetPurchaseByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет закупку
        /// </summary>
        /// <param name="id">Идентификатор обновляемой закупки</param>
        /// <param name="purchase">Объект с новыми данными закупки</param>
        /// <returns>true - успешно, false - ошибка</returns>
        Task<bool> UpdatePurchaseAsync(int id, Purchase purchase);

        /// <summary>
        /// Создает новую закупку
        /// </summary>
        /// <param name="purchase">Объект закупки для создания</param>
        /// <returns>Созданный объект закупки</returns>
        Task<Purchase> CreatePurchaseAsync(Purchase purchase);

        /// <summary>
        /// Удаляет закупку по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемой закупки</param>
        /// <returns>true - успешно, false - ошибка</returns>
        Task<bool> DeletePurchaseAsync(int id);
    }
}