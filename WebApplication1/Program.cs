using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Concrete;
using Repositories.Context;
using Services.Abstract;
using Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CarContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Server=DESKTOP-MJTOPVQ\\SQLEXPRESS;Database=Cars;Trusted_Connection=True;"));
});

builder.Services.AddTransient(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
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
