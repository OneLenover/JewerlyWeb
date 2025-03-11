using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetAllReviewsAsync(CancellationToken cancellation);
        Task<Review> GetReviewByIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> UpdateReviewAsync(int id, Review review);
        Task<Review> CreateReviewAsync(Review review);
        Task<bool> DeleteReviewAsync(int id);
    }
}
