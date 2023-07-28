using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using asp_test4.Models;

namespace asp_test4.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        System.Console.WriteLine("Hello World");
        var model = new CounterViewModel();
        model.CurrentCount = 4;
        return View(model);
    }
    [HttpPost]
    public IActionResult Inc(CounterViewModel model)
    {
        System.Console.WriteLine("inci " + model.CurrentCount);
        model.CurrentCount += 1;
        return View("Index", model);
    }
    public IActionResult Reset(CounterViewModel model)
    {
        model.CurrentCount = 0;
        return View("Index", model);
    }
    public IActionResult Dec(CounterViewModel model)
    {
        model.CurrentCount -= 1;
        return View("Index", model);
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
