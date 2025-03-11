using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;

namespace JewelryWeb.Services
{
    public class ReviewService : IReviewService
    {
        private readonly AppDbContext _context;

        public ReviewService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsAsync(CancellationToken cancellationToken)
        {
            return await _context.Reviews.ToListAsync(cancellationToken);
        }

        public async Task<Review> GetReviewByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Reviews.FindAsync(id, cancellationToken);
        }

        public async Task<bool> UpdateReviewAsync(int id, Review review)
        {
            if (id != review.Id)
            {
                return false;
            }

            _context.Entry(review).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Review> CreateReviewAsync(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<bool> DeleteReviewAsync(int id)
        {
            var review = new Review { Id = id };
            _context.Reviews.Attach(review);
            _context.Reviews.Remove(review);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
