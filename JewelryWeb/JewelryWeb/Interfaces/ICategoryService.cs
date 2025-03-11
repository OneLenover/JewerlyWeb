using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken);
        Task<Category> GetCategoryByIdAsync(int id, CancellationToken cancellation);
        Task<bool> UpdateCategoryAsync(int id, Category category);
        Task<Category> CreateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}