using CarServiceTracking.Core.Abstracts;
using CarServiceTracking.Data.Contexts;
using CarServiceTracking.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using CarServiceTracking.Business;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// DbContext (SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Business Services (AutoMapper, FluentValidation, Services)
builder.Services.AddBusinessServices();

// Controllers
builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
