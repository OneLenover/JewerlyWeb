using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace JewelryWeb
{
    /// <summary>
    /// Middleware для глобальной обработки исключений в приложении
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        /// <summary>
        /// Создает новый экземпляр>.
        /// </summary>
        /// <param name="next">Делегат запроса, передающий управление следующему</param>
        /// <param name="logger">Логирование для записи информации об ошибках</param>
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Обрабатывает HTTP-запрос и перехватывает возможные исключения
        /// </summary>
        /// <param name="context">Контекст HTTP-запроса</param>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogWarning(ex, "Конфликт данных при обновлении в БД.");
                await HandleConcurrencyExceptionAsync(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Непредвиденная ошибка.");
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Обрабатывает исключение, связанное с конфликтом при обновлении данных в БД
        /// </summary>
        /// <param name="context">Контекст HTTP-запроса</param>
        private static Task HandleConcurrencyExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;

            var response = new
            {
                statusCode = context.Response.StatusCode,
                message = "Конфликт данных. Попробуйте ещё раз."
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        /// <summary>
        /// Обрабатывает общее исключение
        /// </summary>
        /// <param name="context">Контекст HTTP-запроса</param>
        /// <param name="ex">Исключение, вызвавшее ошибку</param>
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                statusCode = context.Response.StatusCode,
                message = "Произошла ошибка на сервере.",
                error = ex.Message
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}