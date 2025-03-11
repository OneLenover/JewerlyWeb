using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    public interface IPaymentsService
    {
        Task<IEnumerable<Payment>> GetAllPaymentsAsync(CancellationToken cancellationToken);
        Task<Payment> GetPaymentByIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> UpdatePaymentAsync(int id, Payment payment);
        Task<Payment> CreatePaymentAsync(Payment payment);
        Task<bool> DeletePaymentAsync(int id);
    }
}