using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace JewelryWeb.Controllers
{
    /// <summary>
    /// Контроллер для управления заказами
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        /// <summary>
        /// Конструктор контроллера заказов
        /// </summary>
        /// <param name="ordersService">Сервис заказов</param>
        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        /// <summary>
        /// Получает список всех заказов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех заказов</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders(CancellationToken cancellationToken)
        {
            var orders = await _ordersService.GetAllOrdersAsync(cancellationToken);
            return Ok(orders);
        }

        /// <summary>
        /// Получает заказ по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор заказа</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект заказа</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id, CancellationToken cancellationToken)
        {
            var order = await _ordersService.GetOrderByIdAsync(id, cancellationToken);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        /// <summary>
        /// Обновляет заказ
        /// </summary>
        /// <param name="id">Идентификатор обновляемого заказа</param>
        /// <param name="order">Объект с новыми данными заказа</param>
        /// <returns>Результат обновления</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            var update = await _ordersService.UpdateOrderAsync(id, order);
            if (!update)
            {
                return BadRequest();
            }

            return NoContent();
        }

        /// <summary>
        /// Создает новый заказ
        /// </summary>
        /// <param name="order">Объект заказа для создания</param>
        /// <returns>Созданный объект заказа</returns>
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            var createdOrder = await _ordersService.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.Id }, createdOrder);
        }

        /// <summary>
        /// Удаляет заказ по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемого заказа</param>
        /// <returns>Результат удаления</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var deleted = await _ordersService.DeleteOrderAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}