using InventoryManagement.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;
    private readonly IProblemDetailsService _problemDetails;

    public GlobalExceptionHandler(
        ILogger<GlobalExceptionHandler> logger,
        IProblemDetailsService problemDetails)
    {
        _logger = logger;
        _problemDetails = problemDetails;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        // 1) Logging
        _logger.LogError(exception,
            "Unhandled exception. TraceId: {TraceId}",
            httpContext.TraceIdentifier);

        // 2) Match exception → status + title
        var (status, title) = exception switch
        {
            FluentValidation.ValidationException => (StatusCodes.Status400BadRequest, "Validation Error"),
            NotFoundException nf => (StatusCodes.Status404NotFound, nf.Message),
            KeyNotFoundException => (StatusCodes.Status404NotFound, "Resource Not Found"),
            ArgumentException => (StatusCodes.Status400BadRequest, "Invalid Request"),

            _ => (StatusCodes.Status500InternalServerError, "Server Error")
        };

        var env = httpContext.RequestServices.GetRequiredService<IHostEnvironment>();

        // 3) Create ProblemDetails
        var problem = new ProblemDetails
        {
            Status = status,
            Title = title,
            Type = exception.GetType().Name,
            Detail = env.IsDevelopment()
                     ? exception.Message   // في التطوير فقط
                     : null,
            Instance = httpContext.Request.Path
        };

        // 4) Always add metadata
        problem.Extensions["traceId"] = httpContext.TraceIdentifier;
        problem.Extensions["timestamp"] = DateTime.UtcNow;

        // 5) Special case → ValidationError
        if (exception is FluentValidation.ValidationException validationEx)
        {
            var errors = validationEx.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.ErrorMessage).ToArray()
                );

            problem.Title = "Validation Error";
            problem.Detail = "One or more validation errors occurred.";
            problem.Extensions["errors"] = errors;
        }

        // 6) Write response
        await _problemDetails.WriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            ProblemDetails = problem,
        });

        return true;
    }
}
