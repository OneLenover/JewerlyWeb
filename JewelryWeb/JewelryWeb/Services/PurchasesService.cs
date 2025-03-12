using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;

namespace JewelryWeb.Services
{
    /// <summary>
    /// Сервис для управления закупками
    /// </summary>
    public class PurchaseService : IPurchaseService
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Конструктор сервиса категорий
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public PurchaseService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает список всех закупок
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех закупок</returns>
        public async Task<IEnumerable<Purchase>> GetAllPurchasesAsync(CancellationToken cancellationToken)
        {
            return await _context.Purchases.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Получает закупку по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор закупки</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект закупки</returns>
        public async Task<Purchase> GetPurchaseByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Purchases.FindAsync(id, cancellationToken);
        }

        /// <summary>
        /// Обновляет закупку
        /// </summary>
        /// <param name="id">Идентификатор обновляемой закупки</param>
        /// <param name="purchase">Объект с новыми данными закупки</param>
        /// <returns>true - успешно, false - ошибка</returns>
        public async Task<bool> UpdatePurchaseAsync(int id, Purchase purchase)
        {
            if (id != purchase.Id)
            {
                return false;
            }

            _context.Entry(purchase).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Создает новую закупку
        /// </summary>
        /// <param name="purchase">Объект закупки для создания</param>
        /// <returns>Созданный объект закупки</returns>
        public async Task<Purchase> CreatePurchaseAsync(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();
            return purchase;
        }

        /// <summary>
        /// Удаляет закупку по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемой закупки</param>
        /// <returns>true - успешно, false - ошибка</returns>
        public async Task<bool> DeletePurchaseAsync(int id)
        {
            var purchase = new Purchase { Id = id };
            _context.Purchases.Attach(purchase);
            _context.Purchases.Remove(purchase);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
