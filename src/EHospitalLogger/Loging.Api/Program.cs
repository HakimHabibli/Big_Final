namespace Loging.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddScoped<ExceptionHandlerMiddleware>();

            // MongoLogService-i qeydiyyatı
            builder.Services.AddSingleton<MongoLogService>(sp =>
                new MongoLogService(
                    builder.Configuration["MongoSettings:ConnectionString"],
                    builder.Configuration["MongoSettings:DatabaseName"],
                    builder.Configuration["MongoSettings:CollectionName"]
                ));
            //MongoSettings:

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient("LoggingClient", client =>
            {
                client.BaseAddress = new Uri("http://localhost:5001/");
            });





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
}
