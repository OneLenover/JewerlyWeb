using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;
using System.Threading;

namespace JewelryWeb.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(CancellationToken cancellationToken)
        {
            return await _context.Orders.ToListAsync(cancellationToken);
        }

        public async Task<Order> GetOrderByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Orders.FindAsync(id, cancellationToken);
        }

        public async Task<bool> UpdateOrderAsync(int id, Order order)
        {
            if (id != order.Id)
            {
                return false;
            }

            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = new Order { Id = id };
            _context.Orders.Attach(order);
            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}