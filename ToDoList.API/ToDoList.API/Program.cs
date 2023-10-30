using Microsoft.EntityFrameworkCore;
using ToDoList.API.Data;
using Microsoft.Extensions;
using ToDoList.API.Utils;
using ToDoList.API.Services;
using ToDoList.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
UtilsConfig.ConfigureServices(builder.Services);
RepoConfig.ConfigureServices(builder.Services);
ServicesConfig.ConfigureServices(builder.Services);
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
