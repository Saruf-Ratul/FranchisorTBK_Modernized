using FranchisorTBK.Application;
using FranchisorTBK.Infrastructure;
using FranchisorTBK.Infrastructure.Data;
using FranchisorTBK.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using FranchisorTBK.Application.Interfaces;
using FranchisorTBK.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins("http://localhost:5173") // React dev server
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


// Add EF Core
builder.Services.AddDbContext<FranchisorDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register application/infrastructure services
builder.Services.AddScoped<IFranchiseeRepository, FranchiseeRepository>();
builder.Services.AddApplicationServices();

var app = builder.Build();

// Middleware
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors();

app.Run();
