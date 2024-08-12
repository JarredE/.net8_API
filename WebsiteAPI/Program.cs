using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using WebsiteAPI.Data;
using WebsiteAPI.Entities;
using WebsiteAPI.Interfaces;
using WebsiteAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEntityFrameworkMySQL()
    .AddDbContext<WebsiteDbContext>(options =>
    {
        options.UseMySQL(connectionString: builder.Configuration.GetConnectionString("DefaultConnection"));
    });
                
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserInterface, UserRepository>();

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
