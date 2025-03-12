using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;

namespace JewelryWeb.Services
{
    /// <summary>
    /// Сервис для работы с элементами заказа
    /// </summary>
    public class OrderElementsService : IOrderElementsService
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Конструктор сервиса категорий
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public OrderElementsService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает список всех элементов заказа
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех элементов заказа</returns>
        public async Task<IEnumerable<OrderElements>> GetAllOrderElementsAsync(CancellationToken cancellationToken)
        {
            return await _context.OrdersElements.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Получает элемент заказа по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор элемента заказа</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект элемента заказа</returns>
        public async Task<OrderElements> GetOrderElementByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.OrdersElements.FindAsync(id, cancellationToken);
        }

        /// <summary>
        /// Обновляет данные элемента заказа
        /// </summary>
        /// <param name="id">Идентификатор элемента заказа</param>
        /// <param name="orderElement">Объект с новыми данными элемента заказа</param>
        /// <returns>true - успешно, false - ошибка</returns>
        public async Task<bool> UpdateOrderElementAsync(int id, OrderElements orderElement)
        {
            if (id != orderElement.Id)
            {
                return false;
            }

            _context.Entry(orderElement).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Создает новый элемент заказа
        /// </summary>
        /// <param name="orderElement">Объект элемента заказа для создания</param>
        /// <returns>Созданный объект элемента заказа</returns>
        public async Task<OrderElements> CreateOrderElementAsync(OrderElements orderElement)
        {
            _context.OrdersElements.Add(orderElement);
            await _context.SaveChangesAsync();
            return orderElement;
        }

        /// <summary>
        /// Удаляет элемент заказа по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор элемента заказа</param>
        /// <returns>true - успешно, false - ошибка</returns>
        public async Task<bool> DeleteOrderElementAsync(int id)
        {
            var orderElement = new OrderElements { Id = id };
            _context.OrdersElements.Attach(orderElement);
            _context.OrdersElements.Remove(orderElement);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}