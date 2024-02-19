using Microsoft.Extensions.DependencyInjection;
using System;

var services  = new ServiceCollection();
services.AddScoped<ILogService, SimpleLogService>();
services.AddTransient <Logger>();


using var serviceProvider = services.BuildServiceProvider();

Logger? logger = serviceProvider.GetService<Logger>();
logger.Log("Добро пожаловать!");

interface ILogService
{
    void Write(string message);
}

class SimpleLogService : ILogService
{
    public SimpleLogService()
    {
        Console.WriteLine("Создался сервис");
    }
    public void Write(string message) => Console.WriteLine(message);
}

class RedLogService : ILogService
{
    public void Write(string message)
    {
        var defaultColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = defaultColor;
    }
}

class Logger
{
    ILogService? logService;
    public Logger(ILogService? logService) =>this.logService = logService;
    public void Log(string message)
    {
        logService?.Write($"{DateTime.Now} {message}");
        logService?.Write($"{DateTime.Now} Проверка выполнения логирования");
    }
}