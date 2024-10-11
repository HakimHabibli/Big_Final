using MongoDB.Driver;

namespace Loging.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<ILogService, MongoLogService>();

        builder.Services.AddSingleton<IMongoClient>(sp =>
        {
            var connectionString = "mongodb://localhost:27017/"; // Burada MongoDB bağlantısını qeyd edin
            return new MongoClient(connectionString);
        });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
