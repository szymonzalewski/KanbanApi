﻿global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
using KanbanApi;
using KanbanApi.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<KanabanApiDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("KanbanApiConnectinString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
