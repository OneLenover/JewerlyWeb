using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JewelryWeb.Models;
using JewelryWeb.Interfaces;
using System.Threading;
using BCrypt.Net;

namespace JewelryWeb.Services
{
    /// <summary>
    /// Сервис для работы с пользователями
    /// </summary>
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Конструктор сервиса категорий
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Регистрирует нового пользователя
        /// </summary>
        /// <param name="email">Электронная почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>Зарегистрированный пользователь</returns>
        public async Task<User> Register(string email, string password)
        {
            var user = new User
            {
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        /// <summary>
        /// Аутентифицирует пользователя
        /// </summary>
        /// <param name="email">Электронная почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>Аутентифицированный пользователь или null, если аутентификация не удалась</returns>
        public async Task<User?> Authenticate(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return null;
            }
            return user;
        }
    }
}