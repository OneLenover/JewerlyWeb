using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;
using System.Threading;

namespace JewelryWeb.Services
{
    public class ClientService : IClientService
    {
        private readonly AppDbContext _context;

        public ClientService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync(CancellationToken cancellationToken)
        {
            return await _context.Clients.ToListAsync(cancellationToken);
        }

        public async Task<Client> GetClientByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Clients.FindAsync(id, cancellationToken);
        }

        public async Task<bool> UpdateClientAsync(int id, Client client)
        {
            if (id != client.Id)
            {
                return false;
            }

            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Client> CreateClientAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            var client = new Client { Id = id };
            _context.Clients.Attach(client);
            _context.Clients.Remove(client);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}