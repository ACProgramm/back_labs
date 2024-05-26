using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class HomeController : Controller
{
    private readonly IMemoryCache _memoryCache;
    private const string CacheKey = "ApiData";
    private readonly Stopwatch _stopwatch;

    public HomeController(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
        _stopwatch = new Stopwatch();
    }

    private static readonly List<string> SampleData = new List<string>
    {
        "Item 1",
        "Item 2",
        "Item 3"
    };

    [HttpGet("")]
    public IActionResult Index()
    {
        string cacheKey = "currentTime";
        if (!_memoryCache.TryGetValue(cacheKey, out string currentTime))
        {
            currentTime = DateTime.Now.ToString();
            _memoryCache.Set(cacheKey, currentTime, TimeSpan.FromMinutes(1));
        }

        ViewBag.CurrentTime = currentTime;
        return View();
    }

    [HttpGet("items")]
    public IActionResult GetAllItems()
    {
        List<string> data;

        _stopwatch.Restart();

        // Пытаемся получить данные из кэша
        if (_memoryCache.TryGetValue(CacheKey, out List<string> cachedData))
        {
            System.Threading.Thread.Sleep(100); // Искусственная задержка в 100 мс
            data = cachedData;
            _stopwatch.Stop();
            Console.WriteLine($"Данные получены из кэша за {_stopwatch.ElapsedMilliseconds} мс");
        }
        else
        {
            _stopwatch.Restart();

            // Если данные не найдены в кэше, загружаем их из источника данных
            data = LoadDataFromSource();
            System.Threading.Thread.Sleep(100); // Искусственная задержка в 100 мс
            _stopwatch.Stop();
            Console.WriteLine($"Данные получены из источника данных за {_stopwatch.ElapsedMilliseconds} мс");

            // Сохраняем данные в кэше на будущее
            _memoryCache.Set(CacheKey, data, TimeSpan.FromHours(1));
        }

        return Ok(data);
    }

    private List<string> LoadDataFromSource()
    {
        // Здесь можно реализовать код для загрузки данных из источника данных (например, базы данных или другого сервиса)
        // В этом примере просто возвращаем тестовые данные
        return new List<string>
        {
            "Item 1",
            "Item 2",
            "Item 3"
        };
    }
}
