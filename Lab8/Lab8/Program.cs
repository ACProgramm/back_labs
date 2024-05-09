var builder = WebApplication.CreateBuilder(args);

// ��������� ������� MVC � ��������� ������������.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(); // ��������� ������� ������

var app = builder.Build();

// ��������� ��������� HTTP-��������.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // ������������� HSTS ��� ��������� ������������ (�������������).
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ����� �������������� �������� ����� ������������� �������� UseSession
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
