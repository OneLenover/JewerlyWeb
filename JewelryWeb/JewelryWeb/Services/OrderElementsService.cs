using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;

namespace JewelryWeb.Services
{
    public class OrderElementsService : IOrderElementsService
    {
        private readonly AppDbContext _context;

        public OrderElementsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderElements>> GetAllOrderElementsAsync(CancellationToken cancellationToken)
        {
            return await _context.OrdersElements.ToListAsync(cancellationToken);
        }

        public async Task<OrderElements> GetOrderElementByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.OrdersElements.FindAsync(id, cancellationToken);
        }

        public async Task<bool> UpdateOrderElementAsync(int id, OrderElements orderElement)
        {
            if (id != orderElement.Id)
            {
                return false;
            }

            _context.Entry(orderElement).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<OrderElements> CreateOrderElementAsync(OrderElements orderElement)
        {
            _context.OrdersElements.Add(orderElement);
            await _context.SaveChangesAsync();
            return orderElement;
        }

        public async Task<bool> DeleteOrderElementAsync(int id)
        {
            var orderElement = new Order { Id = id };
            _context.Orders.Attach(orderElement);
            _context.Orders.Remove(orderElement);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}