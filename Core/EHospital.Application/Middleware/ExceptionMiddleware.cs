namespace EHospital.Application.Middleware;

//public class ExceptionMiddleware
//{
//    private readonly RequestDelegate _next;
//    private readonly ILogService _logService;

//    public ExceptionMiddleware(RequestDelegate next, ILogService logService)
//    {
//        _next = next;
//        _logService = logService;
//    }

//    public async Task InvokeAsync(HttpContext context)
//    {
//        try
//        {
//            await _next(context);
//            //// Müvəffəqiyyətli cavabları loglayır lakin performansa çox aşağı salır 
//            //if (context.Response.StatusCode >= 200 && context.Response.StatusCode < 300)
//            //{
//            //    var logEntry = new LogEntry
//            //    {
//            //        Message = $"Successful request to {context.Request.Path}",
//            //        LogLevel = LogLevel.Information,
//            //        Timestamp = DateTime.UtcNow
//            //    };
//            //    await _logService.LogAsync(logEntry);
//            //}
//        }
//        catch (ValidationException ex)
//        {
//            await HandleValidationExceptionAsync(context, ex);
//        }
//        catch (NotFoundException ex)
//        {
//            await HandleNotFoundExceptionAsync(context, ex);
//        }
//        catch (UnAuthorizedException ex)
//        {
//            await HandleUnauthorizedExceptionAsync(context, ex);
//        }
//        catch (BusinessRuleException ex)
//        {
//            await HandleBusinessRuleExceptionAsync(context, ex);
//        }
//        catch (Exception ex)
//        {
//            await HandleExceptionAsync(context, ex);
//        }
//    }
//    private async Task HandleUnauthorizedExceptionAsync(HttpContext context, UnAuthorizedException ex)
//    {
//        var logEntry = new LogEntry
//        {
//            Message = ex.Message,
//            LogLevel = LogLevel.Error,
//            Timestamp = DateTime.UtcNow
//        };
//        await _logService.LogAsync(logEntry);

//        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
//        await context.Response.WriteAsJsonAsync(new { message = ex.Message });
//    }
//    private async Task HandleValidationExceptionAsync(HttpContext context, ValidationException ex)
//    {

//        var logEntry = new LogEntry
//        {
//            Message = string.Join(", ", ex.ValidationErrors),
//            LogLevel = LogLevel.Warning,
//            Timestamp = DateTime.UtcNow
//        };
//        await _logService.LogAsync(logEntry);


//        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
//        await context.Response.WriteAsJsonAsync(new { errors = ex.ValidationErrors });
//    }

//    private async Task HandleNotFoundExceptionAsync(HttpContext context, NotFoundException ex)
//    {

//        var logEntry = new LogEntry
//        {
//            Message = ex.Message,
//            LogLevel = LogLevel.Warning,
//            Timestamp = DateTime.UtcNow
//        };
//        await _logService.LogAsync(logEntry);


//        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
//        await context.Response.WriteAsJsonAsync(new { message = ex.Message });
//    }

//    private async Task HandleBusinessRuleExceptionAsync(HttpContext context, BusinessRuleException ex)
//    {

//        var logEntry = new LogEntry
//        {
//            Message = ex.Message,
//            LogLevel = LogLevel.Warning,
//            Timestamp = DateTime.UtcNow
//        };
//        await _logService.LogAsync(logEntry);


//        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
//        await context.Response.WriteAsJsonAsync(new { message = ex.Message });
//    }

//    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
//    {

//        var logEntry = new LogEntry
//        {
//            Message = ex.Message,
//            LogLevel = LogLevel.Error,
//            Timestamp = DateTime.UtcNow
//        };
//        await _logService.LogAsync(logEntry);

//        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//        await context.Response.WriteAsJsonAsync(new { message = "Internal Server Error" });
//    }
//}




