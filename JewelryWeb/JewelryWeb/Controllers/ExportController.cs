using Microsoft.AspNetCore.Mvc;
using Microsoft.DiaSymReader;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;

namespace JewelryWeb.Controllers
{
    public class ExportController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public ExportController(AppDbContext context)
        {
            _context = context;
        }

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

                var worksheet = workbook.Worksheets.Add(tableName);
                worksheet.Cell(1, 1).InsertTable(table);
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;

            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DatabaseExport.xlsx");
        }

        private async Task<DataTable> ConvertToDataTableAsync(System.Reflection.PropertyInfo dbSetProperty)
        {
            var dbSet = dbSetProperty.GetValue(_context);
            if (dbSet is not IQueryable<object> queryable) return null;

            var data = await queryable.ToListAsync();
            if (data.Count == 0) return null;

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