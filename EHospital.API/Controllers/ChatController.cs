using EHospital.Persistence.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly AppDbContext _context;

    public ChatController(HttpClient httpClient, AppDbContext context)
    {
        _httpClient = httpClient;
        _context = context;
    }
    public class ChatRequest
    {
        public string Message { get; set; }
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> SendMessage([FromBody] ChatRequest request)
    {
        // İstifadəçi emailini əldə edirik (Identity sistemindən)
        var userEmail = User.Identity?.Name;
        if (string.IsNullOrEmpty(userEmail))
        {
            return Unauthorized("User is not logged in.");
        }

        var apiKey = "AIKey";
        var url = "https://api.openai.com/v1/chat/completions";

        var content = new StringContent(
            JsonConvert.SerializeObject(new
            {
                model = "gpt-4",
                messages = new[]
                {
                    new { role = "user", content = request.Message },
                    new { role = "system", content = "Cavab yalnız Azərbaycan dilində olmalıdır." }
                }
            }), Encoding.UTF8, "application/json");

        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        var response = await _httpClient.PostAsync(url, content);

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            dynamic responseJson = JsonConvert.DeserializeObject(responseBody);
            string aiMessage = responseJson.choices[0].message.content;

            
            var chatHistory = new ChatHistory
            {
                UserEmail = userEmail,
                UserMessage = request.Message,
                AIResponse = aiMessage,
                CreatedAt = DateTime.Now
            };

            _context.ChatHistories.Add(chatHistory);
            await _context.SaveChangesAsync();

            return Ok(new { Response = aiMessage });
        }
        else
        {
            var errorBody = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, $"Xəta baş verdi: Status {response.StatusCode}, Detal: {errorBody}");
        }
    }
}
