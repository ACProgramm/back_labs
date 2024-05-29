using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Prometheus;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();

        // Настройка метрик Prometheus
        app.UseHttpMetrics();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapMetrics(); // Добавляет /metrics endpoint
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
