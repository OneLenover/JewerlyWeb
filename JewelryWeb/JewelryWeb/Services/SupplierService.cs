using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;

namespace JewelryWeb.Services
{
    /// <summary>
    /// Сервис для управления поставщиков
    /// </summary>
    public class SupplierService : ISupplierService
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Конструктор сервиса категорий
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public SupplierService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает список всех поставщиков
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех поставщиков</returns>
        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync(CancellationToken cancellationToken)
        {
            return await _context.Suppliers.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Получает поставщика по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор поставщика</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект поставщика</returns>
        public async Task<Supplier> GetSupplierByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Suppliers.FindAsync(id, cancellationToken);
        }

        /// <summary>
        /// Обновляет поставщика
        /// </summary>
        /// <param name="id">Идентификатор обновляемого поставщика</param>
        /// <param name="supplier">Объект с новыми данными поставщика</param>
        /// <returns>true - успешно, false - ошибка</returns>
        public async Task<bool> UpdateSupplierAsync(int id, Supplier supplier)
        {
            if (id !=  supplier.Id)
            {
                return false;
            }

            _context.Entry(supplier).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Создает нового поставщика
        /// </summary>
        /// <param name="supplier">Объект поставщика для создания</param>
        /// <returns>Созданный объект поставщика</returns>
        public async Task<Supplier> CreateSupplierAsync(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        /// <summary>
        /// Удаляет поставщика по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемого поставщика</param>
        /// <returns>true - успешно, false - ошибка</returns>
        public async Task<bool> DeleteSupplierAsync(int id)
        {
            var supplier = new Supplier { Id = id };
            _context.Suppliers.Attach(supplier);
            _context.Suppliers.Remove(supplier);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
