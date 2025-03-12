using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с клиентами
    /// </summary>
    public interface IClientService
    {
        /// <summary>
        /// Получает список всех клиентов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех клиентов</returns>
        Task<IEnumerable<Client>> GetAllClientsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает клиента по id
        /// </summary>
        /// <param name="id">Идентификатор клиента</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект клиента</returns>
        Task<Client> GetClientByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет клиента
        /// </summary>
        /// <param name="id">Идентификатор обновляемого клиента</param>
        /// <param name="client">Объект с новыми данными</param>
        /// <returns>true - успешно, false - ошибка</returns>
        Task<bool> UpdateClientAsync(int id, Client client);

        /// <summary>
        /// Создает нового клиента
        /// </summary>
        /// <param name="client">Объект клиента для создания</param>
        /// <returns>Созданный объект клиента</returns>
        Task<Client> CreateClientAsync(Client client);

        /// <summary>
        /// Удаляет клиента по id
        /// </summary>
        /// <param name="id">Идентификатор удаляемого клиента</param>
        /// <returns>true - успешно, false - ошибка</returns>
        Task<bool> DeleteClientAsync(int id);
    }
}