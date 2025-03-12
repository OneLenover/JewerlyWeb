using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;
using System.Threading;

namespace JewelryWeb.Services
{
    /// <summary>
    /// Сервис для управления категориями товаров
    /// </summary>
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Конструктор сервиса категорий
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает список всех категорий
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список категорий</returns>
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            return await _context.Categories.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Получает категорию по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор категории</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Объект категории</returns>
        public async Task<Category> GetCategoryByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Categories.FindAsync(id, cancellationToken);
        }

        /// <summary>
        /// Обновляет данные категории
        /// </summary>
        /// <param name="id">Идентификатор категории</param>
        /// <param name="category">Обновленный объект категории</param>
        /// <returns>True, если обновление успешно, иначе false</returns>
        public async Task<bool> UpdateCategoryAsync(int id, Category category)
        {
            if (id != category.Id)
            {
                return false;
            }

            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Создает новую категорию
        /// </summary>
        /// <param name="category">Объект категории</param>
        /// <returns>Созданная категория</returns>
        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        /// <summary>
        /// Удаляет категорию по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор категории</param>
        /// <returns>True, если удаление успешно</returns>
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = new Category { Id = id };
            _context.Categories.Attach(category);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}