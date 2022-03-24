global using FastEndpoints;
global using FastEndpoints.Validation;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using ToDoDemo.API.Endpoints;
using ToDoDemo.Data;
using ToDoDemo.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "ToDoCorsPolicy",
                      builder =>
                      {
                          builder.WithOrigins("https://localhost:7221");
                      });
});


builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();
//builder.Services.AddScoped(x=>x.)
//builder.Services.AddTransient<Endpoint<ToDoDTO>, GetToDoEndpoint>();


builder.Services.AddDbContext<ToDoDemoDBContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoDemoCS")));


builder.Services.AddScoped<Endpoint<ToDoDTO>, GetToDoEndpoint>();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseFastEndpoints();

app.UseOpenApi();
app.UseSwaggerUi3(c => c.ConfigureDefaults()); 

app.Run();
