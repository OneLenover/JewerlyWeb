using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace JewelryWeb.Controllers
{
    /// <summary>
    /// Контроллер для управления элементами заказа
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderElementsController : ControllerBase
    {
        private readonly IOrderElementsService _orderElementsService;

        /// <summary>
        /// Конструктор контроллера элементов заказа
        /// </summary>
        /// <param name="orderElementsService">Сервис элементов заказа</param>
        public OrderElementsController(IOrderElementsService orderElementsService)
        {
            _orderElementsService = orderElementsService;
        }

        /// <summary>
        /// Получает список всех элементов заказа
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех элементов заказа</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderElements>>> GetOrdersElements(CancellationToken cancellationToken)
        {
            var orderElements = await _orderElementsService.GetAllOrderElementsAsync(cancellationToken);
            return Ok(orderElements);
        }

        /// <summary>
        /// Получает элемент заказа по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор элемента заказа</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект элемента заказа</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderElements>> GetOrderElements(int id, CancellationToken cancellationToken)
        {
            var orderElement = await _orderElementsService.GetOrderElementByIdAsync(id, cancellationToken);
            if (orderElement == null)
            {
                return NotFound();
            }

            return Ok(orderElement);
        }

        /// <summary>
        /// Обновляет элемент заказа
        /// </summary>
        /// <param name="id">Идентификатор обновляемого элемента заказа</param>
        /// <param name="orderElements">Объект с новыми данными элемента заказа</param>
        /// <returns>Результат обновления</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderElements(int id, OrderElements orderElements)
        {
            var update = await _orderElementsService.UpdateOrderElementAsync(id, orderElements);
            if (!update)
            {
                return BadRequest();
            }

            return NoContent();
        }

        /// <summary>
        /// Создает новый элемент заказа
        /// </summary>
        /// <param name="orderElements">Объект элемента заказа для создания</param>
        /// <returns>Созданный объект элемента заказа</returns>
        [HttpPost]
        public async Task<ActionResult<OrderElements>> PostOrderElements(OrderElements orderElements)
        {
            var createdOrderElement = await _orderElementsService.CreateOrderElementAsync(orderElements);
            return CreatedAtAction(nameof(GetOrderElements), new { id = createdOrderElement.Id }, createdOrderElement);
        }

        /// <summary>
        /// Удаляет элемент заказа по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемого элемента заказа</param>
        /// <returns>Результат удаления</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderElements(int id)
        {
            var deleted = await _orderElementsService.DeleteOrderElementAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}