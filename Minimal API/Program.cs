using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Minimal_API.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Minimal_APIContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Minimal_APIContext") ?? throw new InvalidOperationException("Connection string 'Minimal_APIContext' not found.")));

// Add services to the container.
builder.Services.AddCors(config => config.AddPolicy("Default", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Default");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

