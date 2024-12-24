using Microsoft.EntityFrameworkCore;
using PeriodicTable.API.Repository;
using PeriodicTable.API.Service;
using PeriodicTable.API.Data;

var builder = WebApplication.CreateBuilder(args);

//Add dbcontext and connect it to connection string
builder.Services.AddDbContext<PeriodicTableContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("PeriodicTableDB")));

    


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Inject the proper services
builder.Services.AddScoped<IPeriodicTableService, PeriodicTableService>();
builder.Services.AddScoped<IPeriodicTableRepository, PeriodicTableRepository>();

//Add our controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();