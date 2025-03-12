using JewelryWeb.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using JewelryWeb;
using Microsoft.Extensions.Options;

/// <summary>
/// Контроллер для управления пользователями (регистрация и аутентификация)
/// </summary>
[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly AuthOptions _authOptions;

    /// <summary>
    /// Конструктор контроллера пользователей
    /// </summary>
    /// <param name="userService">Сервис пользователей</param>
    /// <param name="authOptions">Настройки аутентификации</param>
    public UserController(IUserService userService, IOptions<AuthOptions> authOptions)
    {
        _userService = userService;
        _authOptions = authOptions.Value;
    }

    /// <summary>
    /// Регистрирует нового пользователя
    /// </summary>
    /// <param name="model">Модель регистрации пользователя</param>
    /// <returns>Данные зарегистрированного пользователя</returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterModel model)
    {
        var user = await _userService.Register(model.Email, model.Password);
        return Ok(new { user.Id, user.Email });
    }

    /// <summary>
    /// Аутентифицирует пользователя и возвращает JWT-токен
    /// </summary>
    /// <param name="model">Модель аутентификации пользователя</param>
    /// <returns>JWT-токен для доступа</returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginModel model)
    {
        var user = await _userService.Authenticate(model.Email, model.Password);
        if (user == null)
            return Unauthorized("Invalid credentials");

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var jwt = new JwtSecurityToken(
            issuer: _authOptions.Issuer,
            audience: _authOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: new SigningCredentials(_authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        return Ok(new { access_token = new JwtSecurityTokenHandler().WriteToken(jwt) });
    }
}

/// <summary>
/// Модель для регистрации пользователя
/// </summary>
public class UserRegisterModel
{
    /// <summary>
    /// Электронная почта пользователя
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Пароль пользователя
    /// </summary>
    public string Password { get; set; }
}

/// <summary>
/// Модель для аутентификации пользователя
/// </summary>
public class UserLoginModel
{
    /// <summary>
    /// Электронная почта пользователя
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Пароль пользователя
    /// </summary>
    public string Password { get; set; }
}