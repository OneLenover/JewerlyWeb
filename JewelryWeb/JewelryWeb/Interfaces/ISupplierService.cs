using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync(CancellationToken cancellation);
        Task<Supplier> GetSupplierByIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> UpdateSupplierAsync(int id, Supplier supplier);
        Task<Supplier> CreateSupplierAsync(Supplier supplier);
        Task<bool> DeleteSupplierAsync(int id);
    }
}
