using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;

namespace JewelryWeb.Controllers
{
    /// <summary>
    /// Контроллер экспорта базы данных в Excel
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExportController : ControllerBase
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Конструктор контроллера экспорта
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public ExportController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Экспорт всей базы данных в Excel
        /// </summary>
        /// <returns>Файл Excel с данными</returns>
        [HttpGet("export-db")]
        public async Task<IActionResult> ExportDatabaseToExcelAsync()
        {
            using var workbook = new XLWorkbook();

            var dbSets = _context.GetType().GetProperties()
                .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .ToList();

            foreach (var dbSet in dbSets)
            {
                string tableName = dbSet.Name;

                var table = await ConvertToDataTableAsync(dbSet);
                if (table == null) continue;

                var worksheet = workbook.Worksheets.Add(tableName);
                worksheet.Cell(1, 1).InsertTable(table);
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DatabaseExport.xlsx");
        }

        /// <summary>
        /// Преобразует DbSet в DataTable
        /// </summary>
        private async Task<DataTable?> ConvertToDataTableAsync(PropertyInfo dbSetProperty)
        {
            var dbSet = dbSetProperty.GetValue(_context);
            if (dbSet is not IQueryable<object> queryable) return null;

            var data = await queryable.Cast<object>().ToListAsync();
            if (!data.Any()) return null;

            var dataTable = new DataTable(dbSetProperty.Name);
            var properties = data.First().GetType().GetProperties();

            foreach (var prop in properties)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (var item in data)
            {
                var row = dataTable.NewRow();
                foreach (var prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
