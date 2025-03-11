using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken cancellationToken);
        Task<Product> GetProductByIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> UpdateProductAsync(int id, Product product);
        Task<Product> CreateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
    }
}
