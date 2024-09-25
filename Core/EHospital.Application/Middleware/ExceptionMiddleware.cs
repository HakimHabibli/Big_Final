using EHospital.Application.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace EHospital.Application.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex) // Custom Validation Exception
        {
            _logger.LogError($"Validation Error: {ex.Message}");
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync(new
            {
                message = "Validation failed",
                errors = ex.Errors
            });
        }
        catch (NotFoundException ex) // Custom Not Found Exception
        {
            _logger.LogError($"Not Found: {ex.Message}");
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await context.Response.WriteAsJsonAsync(new { message = ex.Message });
        }
        catch (BusinessRuleException ex) // Custom Business Rule Exception
        {
            _logger.LogError($"Business Rule Violation: {ex.Message}");
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;
            await context.Response.WriteAsJsonAsync(new { message = ex.Message });
        }
        catch (Exception ex) // General Exception Handling
        {
            _logger.LogError($"Something went wrong: {ex.Message}");
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(new { message = "Internal Server Error" });
        }
    }
}
