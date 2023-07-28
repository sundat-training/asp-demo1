using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using asp_test4.Models;

namespace asp_test4.Controllers;

public class PersonController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private static List<Person> persons = SeedPersons();


    public PersonController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        var model = new PersonsViewModel();
        model.Persons = persons;
        return View(model);
    }
    public IActionResult Delete(int id)
    {
        persons = persons.Where(p => p.Id != id).ToList();
        return RedirectToAction("Index");
    }
    public IActionResult Reset()
    {
        persons = SeedPersons(); 
        return RedirectToAction("Index");
    }

    private static Person SeedPerson(int id)
    {
        return new Person { Id = id, Name = "John " + id, Age = 20 + id };
    }

    private static List<Person> SeedPersons()
    {
        return Enumerable
                                        .Range(1, 10)
                                        .Select(SeedPerson)
                                        .ToList();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
