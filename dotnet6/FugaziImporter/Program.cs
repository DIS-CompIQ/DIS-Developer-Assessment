using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using FugaziImporter.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<FugaziContext>(options => 
    // options.UseInMemoryDatabase("Fugazi"));
    // using Microsoft.EntityFrameworkCore;
        options.UseSqlite("Data Source=Data/fugazi.db"));
    
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
