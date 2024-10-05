using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger configuration
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Image API",
        Version = "v1"
    });

    c.SchemaFilter<SwaggerFileSchemaFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //    (c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Image API v1");
    //    c.RoutePrefix = string.Empty; // API dökümantasyonunu root URL'de göster
    //    c.EnableDeepLinking();
    //    c.DisplayRequestDuration();
    //});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
