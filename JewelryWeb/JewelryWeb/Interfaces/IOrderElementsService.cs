using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    public interface IOrderElementsService
    {
        Task<IEnumerable<OrderElements>> GetAllOrderElementsAsync(CancellationToken cancellationToken);
        Task<OrderElements> GetOrderElementByIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> UpdateOrderElementAsync(int id, OrderElements orderElement);
        Task<OrderElements> CreateOrderElementAsync(OrderElements orderElement);
        Task<bool> DeleteOrderElementAsync(int id);
    }
}