using EHospital.Persistence.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
//[Authorize(Roles = "Admin")] 
public class ChatHistoryController : ControllerBase
{
    private readonly AppDbContext _context;

    public ChatHistoryController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllChatHistories()
    {
        List<ChatHistory> chatHistories = await _context.ChatHistories.ToListAsync();

        if (chatHistories == null || chatHistories.Count == 0)
        {
            return NotFound("No chat history found.");
        }

        return Ok(chatHistories);
    }
    [HttpGet("user/{email}")]
    public async Task<IActionResult> GetChatHistoryByUserEmail(string email)
    {
        var chatHistories = await _context.ChatHistories
            .Where(ch => ch.UserEmail.ToLower() == email.ToLower())
            .ToListAsync();

        if (chatHistories == null || chatHistories.Count == 0)
        {
            return NotFound($"No chat history found for user with email: {email}");
        }

        return Ok(chatHistories);
    }
}