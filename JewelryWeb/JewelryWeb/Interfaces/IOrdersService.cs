using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    public interface IOrdersService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync(CancellationToken cancellationToken);
        Task<Order> GetOrderByIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> UpdateOrderAsync(int id, Order order);
        Task<Order> CreateOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(int id);
    }
}