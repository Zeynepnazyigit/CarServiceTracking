using CarServiceTracking.API.Middlewares;
using CarServiceTracking.Data.Contexts;
using CarServiceTracking.Data.Seed;
using CarServiceTracking.Data.Repositories;
using CarServiceTracking.Data.UnitOfWork;
using CarServiceTracking.Business.Services;
using CarServiceTracking.Core.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using CarServiceTracking.Business;

var builder = WebApplication.CreateBuilder(args);

// =====================
// DbContext
// =====================
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// =====================
// JWT Authentication
// =====================
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.ASCII.GetBytes(jwtSettings["Key"] ?? throw new InvalidOperationException("Jwt:Key is not configured"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidateAudience = true,
        ValidAudience = jwtSettings["Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

// =====================
// Authorization
// =====================
builder.Services.AddAuthorization();

// =====================
// Infrastructure Layer (Data Access)
// =====================
// Unit of Work Pattern
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Repository Pattern - Domain specific repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
// Generic repository is registered via UnitOfWork when needed

// =====================
// Business Layer (Application Services)
// =====================
builder.Services.AddBusinessServices(); // Business logic services

// =====================
// Application Services (Cross-cutting concerns)
// =====================
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

// =====================
// Controllers
// =====================
builder.Services.AddControllers();

// =====================
// Swagger
// =====================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// =====================
// CORS
// =====================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        // Production'da sadece bilinen originlere izin ver
        if (builder.Environment.IsDevelopment())
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        }
        else
        {
            policy.WithOrigins(
                      "http://localhost:5070",
                      "https://localhost:5070",
                      "https://carservicetracking.com") // Production domain eklenecek
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials();
        }
    });
});

var app = builder.Build();

// =====================
// Database Seeding
// =====================
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await AppDbContextSeed.SeedAsync(dbContext);
}

// =====================
// Middleware
// =====================

// Global Exception Handling (En başta olmalı)
app.UseMiddleware<GlobalExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

// 🔥 KRİTİK SIRA: Authentication BEFORE Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
