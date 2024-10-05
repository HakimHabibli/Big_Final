using Microsoft.AspNetCore.Mvc;

namespace ImageService.Controllers;

public class FileUploadModel
{
    public string FileName { get; set; }
    public IFormFile File { get; set; }
}

[ApiController]
[Route("[controller]")]
public class ImagesController : ControllerBase
{
    private readonly string _imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

    public ImagesController()
    {
        // Yoxla və yaradılmamışsa wwwroot/images qovluğunu yarat
        if (!Directory.Exists(_imagePath))
        {
            Directory.CreateDirectory(_imagePath);
        }
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.FileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return Ok(new { path = filePath });
    }

    [HttpGet("{fileName}")]
    public IActionResult GetFile(string fileName)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

        if (!System.IO.File.Exists(filePath))
        {
            return NotFound("File not found.");
        }

        var fileBytes = System.IO.File.ReadAllBytes(filePath);
        var contentType = "application/octet-stream"; // Genel bir content type, bunu dosya tipine göre değiştirebilirsiniz.
        return File(fileBytes, contentType, fileName);
    }



    // DELETE: /images/delete/{fileName}
    [HttpDelete("delete/{fileName}")]
    public IActionResult DeleteImage(string fileName)
    {
        var filePath = Path.Combine(_imagePath, fileName);

        if (System.IO.File.Exists(filePath))
        {
            System.IO.File.Delete(filePath);
            return Ok("Şəkil silindi.");
        }
        else
        {
            return NotFound("Şəkil tapılmadı.");
        }
    }
}
