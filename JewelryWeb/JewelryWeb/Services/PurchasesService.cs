using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;

namespace JewelryWeb.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly AppDbContext _context;

        public PurchaseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchasesAsync(CancellationToken cancellationToken)
        {
            return await _context.Purchases.ToListAsync(cancellationToken);
        }

        public async Task<Purchase> GetPurchaseByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Purchases.FindAsync(id, cancellationToken);
        }

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

        public async Task<Purchase> CreatePurchaseAsync(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();
            return purchase;
        }

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
