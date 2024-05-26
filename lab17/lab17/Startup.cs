using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using Microsoft.Extensions.Diagnostics.HealthChecks;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();

        // Добавляем сервис для внутреннего кеширования
        services.AddMemoryCache();

        // Добавляем сервис для Redis распределенного кеширования
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = "localhost:7248";
            options.InstanceName = "SampleInstance";
        });

        // Включаем счетчики производительности
        services.AddHealthChecks();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles(new StaticFileOptions
        {
            OnPrepareResponse = ctx =>
            {
                // Устанавливаем 24 часовое кеширование статичных файлов
                ctx.Context.Response.Headers.Append("Cache-Control", "public, max-age=86400");
            }
        });

        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
