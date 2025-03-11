using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;
using System.Threading;

namespace JewelryWeb.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly AppDbContext _context;

        public MaterialService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Material>> GetAllMaterialsAsync(CancellationToken cancellationToken)
        {
            return await _context.Materials.ToListAsync();
        }

        public async Task<Material> GetMaterialByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Materials.FindAsync(id, cancellationToken);
        }

        public async Task<bool> UpdateMaterialAsync(int id, Material material)
        {
            if (id != material.Id)
            {
                return false;
            }

            _context.Entry(material).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Material> CreateMaterialAsync(Material material)
        {
            _context.Materials.Add(material);
            await _context.SaveChangesAsync();
            return material;
        }

        public async Task<bool> DeleteMaterialAsync(int id)
        {
            var material = new Material { Id = id };
            _context.Materials.Attach(material);
            _context.Materials.Remove(material);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}