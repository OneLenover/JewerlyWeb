using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllClientsAsync(CancellationToken cancellationToken);
        Task<Client> GetClientByIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> UpdateClientAsync(int id, Client client);
        Task<Client> CreateClientAsync(Client client);
        Task<bool> DeleteClientAsync(int id);
    }
}