using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;
using System.Threading;

namespace JewelryWeb.Services
{
    public class PaymentsService : IPaymentsService
    {
        private readonly AppDbContext _context;

        public PaymentsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync(CancellationToken cancellationToken)
        {
            return await _context.Payments.ToListAsync(cancellationToken);
        }

        public async Task<Payment> GetPaymentByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Payments.FindAsync(id, cancellationToken);
        }

        public async Task<bool> UpdatePaymentAsync(int id, Payment payment)
        {
            if (id != payment.Id)
            {
                return false;
            }

            _context.Entry(payment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            var payment = new Payment { Id = id };
            _context.Payments.Attach(payment);
            _context.Payments.Remove(payment);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}