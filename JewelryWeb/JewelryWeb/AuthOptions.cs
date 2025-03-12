using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JewelryWeb
{
    /// <summary>
    /// Опции аутентификации для настройки JWT-токенов
    /// </summary>
    public class AuthOptions
    {
        /// <summary>
        /// Издатель токена
        /// </summary>
        public string Issuer { get; set; } = string.Empty;

        /// <summary>
        /// Потребитель токена
        /// </summary>
        public string Audience { get; set; } = string.Empty;

        /// <summary>
        /// Секретный ключ для подписи токена
        /// </summary>
        public string SecretKey { get; set; } = string.Empty;

        /// <summary>
        /// Генерирует симметричный ключ безопасности из секретного ключа
        /// </summary>
        /// <returns>Объект <see cref="SymmetricSecurityKey"/> для подписи токена.</returns>
        public SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
    }
}