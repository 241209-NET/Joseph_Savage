using Microsoft.EntityFrameworkCore;
using PeriodicTable.API.Repository;
using PeriodicTable.API.Service;
using PeriodicTable.API.Data;
using Microsoft.Extensions.Options;
using PeriodicTable.API.Model;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext and connect it to the connection string
builder.Services.AddDbContext<PeriodicTableContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PeriodicTableDB")));

// Configure the Group data from the settings (appsettings.json)
//builder.Services.Configure<List<Group>>(builder.Configuration.GetSection("Group"));

// Add Swagger to the service container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register services and repositories for Dependency Injection
builder.Services.AddScoped<IElementService, ElementService>();
builder.Services.AddScoped<IElementRepository, ElementRepository>();

builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();

builder.Services.AddScoped<IDiscovererService, DiscovererService>();
builder.Services.AddScoped<IDiscovererRepository, DiscovererRepository>();

// Add controllers to the service container
builder.Services.AddControllers();

var app = builder.Build();

// Enable Swagger UI in development environment
if (app.Environment.IsDevelopment())
{   
    Console.WriteLine("Swagger is enabled.");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();