using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;

namespace JewelryWeb.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly AppDbContext _context;

        public SupplierService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync(CancellationToken cancellationToken)
        {
            return await _context.Suppliers.ToListAsync(cancellationToken);
        }

        public async Task<Supplier> GetSupplierByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Suppliers.FindAsync(id, cancellationToken);
        }

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

        public async Task<Supplier> CreateSupplierAsync(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

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
