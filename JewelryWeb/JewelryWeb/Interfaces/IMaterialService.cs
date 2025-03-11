using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    public interface IMaterialService
    {
        Task<IEnumerable<Material>> GetAllMaterialsAsync(CancellationToken cancellationToken);
        Task<Material> GetMaterialByIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> UpdateMaterialAsync(int id, Material material);
        Task<Material> CreateMaterialAsync(Material material);
        Task<bool> DeleteMaterialAsync(int id);
    }
}