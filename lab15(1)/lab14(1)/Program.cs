using lab14_1_.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(); // добавляем сервисы CORS


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Добавление контекста данных в сервисы приложения
builder.Services.AddDbContext<MyDataContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.


// настраиваем CORS
app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/", async (MyDataContext context) => {
    var data = await context.mydatamodel1.ToListAsync();
    return Results.Ok(data);
});

 // app.MapGet("/data", (MyDataContext db) => db.mydatamodel1.ToList());


app.MapControllers();

app.Run();