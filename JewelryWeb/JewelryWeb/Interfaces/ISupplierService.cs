using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с поставщиками
    /// </summary>
    public interface ISupplierService
    {
        /// <summary>
        /// Получает список всех поставщиков
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех поставщиков</returns>
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает поставщика по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор поставщика</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект поставщика</returns>
        Task<Supplier> GetSupplierByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет поставщика
        /// </summary>
        /// <param name="id">Идентификатор обновляемого поставщика</param>
        /// <param name="supplier">Объект с новыми данными поставщика</param>
        /// <returns>true - успешно, false - ошибка</returns>
        Task<bool> UpdateSupplierAsync(int id, Supplier supplier);

        /// <summary>
        /// Создает нового поставщика
        /// </summary>
        /// <param name="supplier">Объект поставщика для создания</param>
        /// <returns>Созданный объект поставщика</returns>
        Task<Supplier> CreateSupplierAsync(Supplier supplier);

        /// <summary>
        /// Удаляет поставщика по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемого поставщика</param>
        /// <returns>true - успешно, false - ошибка</returns>
        Task<bool> DeleteSupplierAsync(int id);
    }
}