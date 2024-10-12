using MongoDB.Driver;


var builder = WebApplication.CreateBuilder(args);
try
{
    builder.Services.AddSingleton<IMongoClient>(new MongoClient("mongodb://localhost:27017"));

}
catch(MongoConnectionException ex) 
{
    Console.WriteLine($"MongoException {ex}");
    throw;
}
catch (Exception ex)
{
    Console.WriteLine($"Exception {ex}");
    throw;
}

builder.Services.AddScoped<ILogService, MongoLogService>();




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
