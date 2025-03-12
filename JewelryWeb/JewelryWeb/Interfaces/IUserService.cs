using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryWeb.Models;

namespace JewelryWeb.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с пользователями
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Регистрирует нового пользователя
        /// </summary>
        /// <param name="email">Электронная почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>Зарегистрированный пользователь</returns>
        Task<User> Register(string email, string password);

        /// <summary>
        /// Аутентифицирует пользователя
        /// </summary>
        /// <param name="email">Электронная почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>Аутентифицированный пользователь или null, если аутентификация не удалась</returns>
        Task<User?> Authenticate(string email, string password);
    }
}