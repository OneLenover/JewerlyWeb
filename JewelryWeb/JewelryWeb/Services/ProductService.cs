using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;
using System.Threading;

namespace JewelryWeb.Services
{
    /// <summary>
    /// Сервис для управления товарами
    /// </summary>
    public class ProductService : IProductsService
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Конструктор сервиса категорий
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает список всех товаров
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список всех товаров</returns>
        public async Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Получает товар по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор товара</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект товара</returns>
        public async Task<Product> GetProductByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Products.FindAsync(id, cancellationToken);
        }

        /// <summary>
        /// Обновляет товар
        /// </summary>
        /// <param name="id">Идентификатор обновляемого товара</param>
        /// <param name="product">Объект с новыми данными товара</param>
        /// <returns>true - успешно, false - ошибка</returns>
        public async Task<bool> UpdateProductAsync(int id, Product product)
        {
            if (id != product.Id)
            {
                return false;
            }

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Создает новый товар
        /// </summary>
        /// <param name="product">Объект товара для создания</param>
        /// <returns>Созданный объект товара</returns>
        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        /// <summary>
        /// Удаляет товар по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемого товара</param>
        /// <returns>true - успешно, false - ошибка</returns>
        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = new Product { Id = id };
            _context.Products.Attach(product);
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
