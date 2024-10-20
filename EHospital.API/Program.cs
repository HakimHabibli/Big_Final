using EHospital.Application;
using EHospital.Domain.Entities.Auth;
using EHospital.Persistence;
using EHospital.Persistence.DAL;
using EHospital.Persistence.Seed;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000",
                                "http://localhost:3001",
                                "http://localhost:5000")
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials();
        });
});


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddPersistenceService();                           // ServiceRegistration Persistence Layer
builder.Services.AddApplicationService(builder.Configuration);      // ServiceRegistration Application Layer

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EHospital API", Version = "v1" });
    //c.EnableAnnotations();
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Token:Audience"],
        ValidIssuer = builder.Configuration["Token:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("USER", policy => policy.RequireRole("User"));
    options.AddPolicy("ADMIN", policy => policy.RequireRole("Admin"));
    options.AddPolicy("DOCTOR", policy => policy.RequireRole("Doctor"));
    options.AddPolicy("SUPERADMIN", policy => policy.RequireRole("Superadmin"));
    options.AddPolicy("MODERATOR", policy => policy.RequireRole("Moderator"));
    
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleSeeder = services.GetRequiredService<RoleSeeder>();
    await roleSeeder.SeedRoles();
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors();
app.UseAuthentication(); 
app.UseAuthorization(); 
app.MapControllers(); 

app.Run(); 
