using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace YourNamespace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            // Добавление JSON конфигурации
            builder.Configuration.AddJsonFile("config.json");

            // Добавление XML конфигурации
            builder.Configuration.AddXmlFile("config.xml");

            // Добавление ini конфигурации
            builder.Configuration.AddIniFile("config.ini");

            app.Map("/", (IConfiguration appConfig) =>
            {
                // Вывод значений из разных конфигурационных файлов
                return $"appconfig['key'] = {appConfig["key"]}\n" +
                       $"appconfig['xmlConfig'] = {appConfig["xmlConfig"]}\n" +
                       $"appconfig['iniConfig'] = {appConfig["iniConfig"]}\n" +
                       $"appconfig['Logging:LogLevel:Default'] = {appConfig["Logging:LogLevel:Default"]}\n";
            });

            app.Run();
        }
    }
}
