using Microsoft.EntityFrameworkCore;
using Server_Back.Models;
using Server_Back.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    var services = builder.Services;
    var env = builder.Environment;
    services.AddDbContext<ServerDbContext>(options => {
        string connectString = builder.Configuration.GetConnectionString("e_market");
        options.UseSqlServer(connectString);
    });
    services.AddScoped<CategoryService, CategoryService>();
    services.AddScoped<ProductService, ProductService>();
}

builder.Services.AddControllers();
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
