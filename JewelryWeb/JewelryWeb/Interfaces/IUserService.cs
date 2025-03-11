using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    public interface IUserService
    {
        Task<User> Register(string email,  string password);
        Task<User?> Authenticate(string email, string password);
    }
}
