using Loging.Api.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class LogsController : ControllerBase
{
    private readonly MongoLogService _logService;

    public LogsController(MongoLogService logService)
    {
        _logService = logService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] LogEntry logEntry)
    {
        if (logEntry == null)
        {
            return BadRequest("Log entry is null");
        }

        await _logService.LogAsync(logEntry);
        return Ok(new { message = "Log added successfully" });
    }
}