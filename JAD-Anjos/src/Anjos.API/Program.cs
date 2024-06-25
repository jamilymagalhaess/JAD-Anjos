using Anjos.API.Configuration;
using Anjos.Database.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string? mySQLConnection = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(mySQLConnection))
{
    throw new InvalidOperationException("A conexão com o banco de dados não foi configurada corretamente.");
}

builder.Services.AddDbContext<AnjosContext>(options =>
    options.UseSqlServer(mySQLConnection));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencyInjectionConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
