var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(); // добавляем сервисы CORS

var app = builder.Build();

// Configure the HTTP request pipeline.


// настраиваем CORS
app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.Map("/", async context => await context.Response.WriteAsync("Hello!"));


app.MapControllers();

app.Run();