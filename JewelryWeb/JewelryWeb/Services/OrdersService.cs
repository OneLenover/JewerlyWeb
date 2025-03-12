using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;
using System.Threading;

namespace JewelryWeb.Services
{
    /// <summary>
    /// Сервис для работы с заказами
    /// </summary>
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Конструктор сервиса категорий
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public OrdersService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает список всех заказов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех заказов</returns>
        public async Task<IEnumerable<Order>> GetAllOrdersAsync(CancellationToken cancellationToken)
        {
            return await _context.Orders.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Получает заказ по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор заказа</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект заказа</returns>
        public async Task<Order> GetOrderByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Orders.FindAsync(id, cancellationToken);
        }

        /// <summary>
        /// Обновляет данные заказа
        /// </summary>
        /// <param name="id">Идентификатор заказа</param>
        /// <param name="order">Объект с новыми данными заказа</param>
        /// <returns>true - успешно, false - ошибка</returns>
        public async Task<bool> UpdateOrderAsync(int id, Order order)
        {
            if (id != order.Id)
            {
                return false;
            }

            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Создает новый заказ
        /// </summary>
        /// <param name="order">Объект заказа для создания</param>
        /// <returns>Созданный объект заказа</returns>
        public async Task<Order> CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        /// <summary>
        /// Удаляет заказ по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор заказа</param>
        /// <returns>true - успешно, false - ошибка</returns>
        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = new Order { Id = id };
            _context.Orders.Attach(order);
            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}