using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;
using System.Threading;

namespace JewelryWeb.Services
{
    /// <summary>
    /// Сервис для работы с клиентами
    /// </summary>
    public class ClientService : IClientService
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Конструктор сервиса категорий
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public ClientService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает список всех клиентов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех клиентов</returns>
        public async Task<IEnumerable<Client>> GetAllClientsAsync(CancellationToken cancellationToken)
        {
            return await _context.Clients.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Получает клиента по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор клиента</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект клиента</returns>
        public async Task<Client> GetClientByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Clients.FindAsync(id, cancellationToken);
        }

        /// <summary>
        /// Обновляет данные клиента
        /// </summary>
        /// <param name="id">Идентификатор клиента</param>
        /// <param name="client">Объект с новыми данными клиента</param>
        /// <returns>true - успешно, false - ошибка</returns>
        public async Task<bool> UpdateClientAsync(int id, Client client)
        {
            if (id != client.Id)
            {
                return false;
            }

            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Создает нового клиента
        /// </summary>
        /// <param name="client">Объект клиента для создания</param>
        /// <returns>Созданный объект клиента</returns>
        public async Task<Client> CreateClientAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        /// <summary>
        /// Удаляет клиента по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор клиента</param>
        /// <returns>true - успешно, false - ошибка</returns>
        public async Task<bool> DeleteClientAsync(int id)
        {
            var client = new Client { Id = id };
            _context.Clients.Attach(client);
            _context.Clients.Remove(client);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}