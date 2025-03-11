using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    public interface IPurchaseService
    {
        Task<IEnumerable<Purchase>> GetAllPurchasesAsync(CancellationToken cancellationToken);
        Task<Purchase> GetPurchaseByIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> UpdatePurchaseAsync(int id, Purchase purchase);
        Task<Purchase> CreatePurchaseAsync(Purchase purchase);
        Task<bool> DeletePurchaseAsync(int id);
    }
}