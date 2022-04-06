global using FastEndpoints;
global using FastEndpoints.Validation;
using FastEndpoints.Swagger;
using ToDoDemo.API.Endpoints;
using ToDoDemo.Models;
using Microsoft.EntityFrameworkCore;
using ToDoDemo.Data;
using ToDoDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddRazorPages()
      .AddRazorRuntimeCompilation(); 

builder.Services.AddDbContext<ToDoDemoDBContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoDemoCS")));

builder.Services.AddScoped<IToDoService, ToDoService>();

builder.Services.AddScoped<EndpointWithoutRequest, GetToDoEndpoint>();
builder.Services.AddScoped<Endpoint<CreateToDoDTO>, CreateToDoEndpoint>();


builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ToDoDemoDBContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


app.UseFastEndpoints();

app.UseOpenApi();
app.UseSwaggerUi3(c => c.ConfigureDefaults());


app.Run();
