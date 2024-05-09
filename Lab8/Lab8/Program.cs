var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы MVC в контейнер зависимостей.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(); // Добавляем сервисы сессий

var app = builder.Build();

// Настройка обработки HTTP-запросов.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // Устанавливаем HSTS для повышения безопасности (необязательно).
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Перед использованием конечных точек маршрутизации вызываем UseSession
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
