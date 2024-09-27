using EHospital.Application.Exceptions; // Custom Exception-lar buradan gəlir
using Loging.Api.Models; // LogEntry və LogLevel üçün
using Microsoft.AspNetCore.Http;
using System.Net;

namespace EHospital.Application.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogService _logService; // Loglama servisini inject edirik

        public ExceptionMiddleware(RequestDelegate next, ILogService logService)
        {
            _next = next;
            _logService = logService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex) // Validation xətası üçün xüsusi davranış
            {
                await HandleValidationExceptionAsync(context, ex);
            }
            catch (NotFoundException ex) // Not Found xətası üçün xüsusi davranış
            {
                await HandleNotFoundExceptionAsync(context, ex);
            }
            catch (BusinessRuleException ex) // Business Rule xətası üçün xüsusi davranış
            {
                await HandleBusinessRuleExceptionAsync(context, ex);
            }
            catch (Exception ex) // Ümumi exception-lar üçün
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleValidationExceptionAsync(HttpContext context, ValidationException ex)
        {
            // Validation exception üçün loglama
            var logEntry = new LogEntry
            {
                Message = string.Join(", ", ex.ValidationErrors),
                LogLevel = LogLevel.Warning,
                Timestamp = DateTime.UtcNow
            };
            await _logService.LogAsync(logEntry);

            // Müvafiq HTTP cavabı
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync(new { errors = ex.ValidationErrors });
        }

        private async Task HandleNotFoundExceptionAsync(HttpContext context, NotFoundException ex)
        {
            // Not Found exception üçün loglama
            var logEntry = new LogEntry
            {
                Message = ex.Message,
                LogLevel = LogLevel.Warning,
                Timestamp = DateTime.UtcNow
            };
            await _logService.LogAsync(logEntry);

            // Müvafiq HTTP cavabı
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await context.Response.WriteAsJsonAsync(new { message = ex.Message });
        }

        private async Task HandleBusinessRuleExceptionAsync(HttpContext context, BusinessRuleException ex)
        {
            // Business Rule exception üçün loglama
            var logEntry = new LogEntry
            {
                Message = ex.Message,
                LogLevel = LogLevel.Warning,
                Timestamp = DateTime.UtcNow
            };
            await _logService.LogAsync(logEntry);

            // Müvafiq HTTP cavabı
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync(new { message = ex.Message });
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // Ümumi xətalar üçün loglama
            var logEntry = new LogEntry
            {
                Message = ex.Message,
                LogLevel = LogLevel.Error,
                Timestamp = DateTime.UtcNow
            };
            await _logService.LogAsync(logEntry);

            // Müvafiq HTTP cavabı
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(new { message = "Internal Server Error" });
        }
    }
}




#region MyRegion

//using Microsoft.AspNetCore.Http;
//using System.Net;
//using System.Text;
//using System.Text.Json;

//namespace EHospital.Application.Middleware
//{
//    public class ExceptionMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private readonly HttpClient _httpClient;

//        public ExceptionMiddleware(RequestDelegate next, IHttpClientFactory clientFactory)
//        {
//            _next = next;
//            _httpClient = clientFactory.CreateClient("LoggingClient");
//        }

//        public async Task InvokeAsync(HttpContext context)
//        {
//            try
//            {
//                await _next(context);
//            }
//            catch (Exception ex)
//            {
//                var logEntry = new
//                {
//                    Message = ex.Message,
//                    LogLevel = "Error",
//                    Timestamp = DateTime.UtcNow
//                };

//                var content = new StringContent(JsonSerializer.Serialize(logEntry), Encoding.UTF8, "application/json");

//                // Loglama servisinə HTTP POST ilə göndər
//                await _httpClient.PostAsync("logs", content);

//                // Müvafiq cavab qaytar
//                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//                await context.Response.WriteAsJsonAsync(new { message = "Internal Server Error" });
//            }
//        }
//    }
//}
#endregion
