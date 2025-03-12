using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с товарами
    /// </summary>
    public interface IProductsService
    {
        /// <summary>
        /// Получает список всех товаров
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех товаров</returns>
        Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает товар по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор товара</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект товара</returns>
        Task<Product> GetProductByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет товар
        /// </summary>
        /// <param name="id">Идентификатор обновляемого товара</param>
        /// <param name="product">Объект с новыми данными товара</param>
        /// <returns>true - успешно, false - ошибка</returns>
        Task<bool> UpdateProductAsync(int id, Product product);

        /// <summary>
        /// Создает новый товар
        /// </summary>
        /// <param name="product">Объект товара для создания</param>
        /// <returns>Созданный объект товара</returns>
        Task<Product> CreateProductAsync(Product product);

        /// <summary>
        /// Удаляет товар по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемого товара</param>
        /// <returns>true - успешно, false - ошибка</returns>
        Task<bool> DeleteProductAsync(int id);
    }
}