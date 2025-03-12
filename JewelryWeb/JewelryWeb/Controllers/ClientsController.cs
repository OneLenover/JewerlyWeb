using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace JewelryWeb.Controllers
{
    /// <summary>
    /// Контроллер для управления клиентами
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        /// <summary>
        /// Конструктор контроллера клиентов
        /// </summary>
        /// <param name="clientService">Сервис категорий</param>
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// Получает список всех клиентов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех клиентов</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients(CancellationToken cancellationToken)
        {
            var clients = await _clientService.GetAllClientsAsync(cancellationToken);
            return Ok(clients);
        }

        /// <summary>
        /// Получает клиента по id
        /// </summary>
        /// <param name="id">Идентификатор клиента</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект клиента</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id, CancellationToken cancellationToken)
        {
            var client = await _clientService.GetClientByIdAsync(id, cancellationToken);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        /// <summary>
        /// Обновляет клиента
        /// </summary>
        /// <param name="id">Идентификатор обновляемого клиента</param>
        /// <param name="client">Объект с новыми данными</param>
        /// <returns>Объект клиента</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            var updated = await _clientService.UpdateClientAsync(id, client);
            if (!updated)
            {
                return BadRequest();
            }

            return NoContent();
        }

        /// <summary>
        /// Создает нового клиента
        /// </summary>
        /// <param name="client">Объект клиента для создания</param>
        /// <returns>Созданный объект клиента</returns>
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            var createdClient = await _clientService.CreateClientAsync(client);
            return CreatedAtAction(nameof(GetClient), new { id = createdClient.Id }, createdClient);
        }

        /// <summary>
        /// Удаляет клиента по id
        /// </summary>
        /// <param name="id">Идентификатор удаляемого клиента</param>
        /// <returns>Резутльтат удаления</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var deleted = await _clientService.DeleteClientAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}