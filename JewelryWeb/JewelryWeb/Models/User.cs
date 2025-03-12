using JewelryWeb.Models;

/// <summary>
/// Описание модели пользователя
/// </summary>
public class User
{
    /// <summary>
    /// Уникальный идентификатор пользователя
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Почта пользователя
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Хэш пароля пользователя
    /// </summary>
    public string PasswordHash { get; set; }

    /// <summary>
    /// Роль пользователя
    /// </summary>
    public string Role { get; set; } = "Client";

    public Client Client { get; set; }
}