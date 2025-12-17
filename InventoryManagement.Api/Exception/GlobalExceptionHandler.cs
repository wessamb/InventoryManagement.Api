using System.Text.Json;

using InventoryManagement.Application.Execption;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Api.Middleware
{
    public sealed class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "Unhandled exception. TraceId: {TraceId}", httpContext.TraceIdentifier);

            var env = httpContext.RequestServices.GetRequiredService<IHostEnvironment>();

            // ✅ معالجة خاصة لـ ValidationException
            if (exception is FluentValidation.ValidationException validationEx)
            {
                var errors = validationEx.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(e => e.ErrorMessage).ToArray()
                    );

                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                httpContext.Response.ContentType = "application/problem+json";

                var validationResponse = new
                {
                    type = "ValidationException",
                    title = "Validation Error",
                    status = 400,
                    detail = "One or more validation errors occurred.",
                    instance = httpContext.Request.Path.ToString(),
                    traceId = httpContext.TraceIdentifier,
                    timestamp = DateTime.UtcNow,
                    errors = errors
                };

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = env.IsDevelopment()
                };

                var json = JsonSerializer.Serialize(validationResponse, options);
                await httpContext.Response.WriteAsync(json, cancellationToken);
                return true;
            }

            // ✅ معالجة باقي الـ Exceptions
            int status;
            string title;

            switch (exception)
            {
                case NotFoundException nf:
                    status = StatusCodes.Status404NotFound;
                    title = nf.Message;
                    break;

                case ConflictException cf:
                    status = StatusCodes.Status409Conflict;
                    title = cf.Message;
                    break;

                case UnauthorizedException ua:
                    status = StatusCodes.Status401Unauthorized;
                    title = ua.Message;
                    break;

                case ForbiddenException fb:
                    status = StatusCodes.Status403Forbidden;
                    title = fb.Message;
                    break;

                case KeyNotFoundException:
                    status = StatusCodes.Status404NotFound;
                    title = "Resource Not Found";
                    break;

                case ArgumentException:
                    status = StatusCodes.Status400BadRequest;
                    title = "Invalid Request";
                    break;

                default:
                    status = StatusCodes.Status500InternalServerError;
                    title = "Server Error";
                    break;
            }

            httpContext.Response.StatusCode = status;
            httpContext.Response.ContentType = "application/problem+json";

            var response = new
            {
                type = exception.GetType().Name,
                title = title,
                status = status,
                detail = env.IsDevelopment()
                         ? exception.Message
                         : (status == 500 ? "An unexpected error occurred" : exception.Message),
                instance = httpContext.Request.Path.ToString(),
                traceId = httpContext.TraceIdentifier,
                timestamp = DateTime.UtcNow
            };

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = env.IsDevelopment()
            };

            var responseJson = JsonSerializer.Serialize(response, jsonOptions);
            await httpContext.Response.WriteAsync(responseJson, cancellationToken);

            return true;
        }
    }
}