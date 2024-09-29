using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Index()
    {
        return View();
    }


    public IActionResult Circle()
    {
        return View(new CircleModel());
    }

    [HttpPost]
    public IActionResult CalculateCircle(CircleModel model)
    {
        if (ModelState.IsValid)
        {
            var radius = model.Radius ?? 0;
            model.Area = Math.PI * Math.Pow(radius, 2);
            model.Diameter = radius * 2;
            model.Circumference = Math.PI * model.Diameter;
        }

        return View("Circle", model);
    }

    public IActionResult Triangle()
    {
        return View(new TriangleModel());
    }

    [HttpPost]
    public IActionResult CalculateTriangle(TriangleModel model)
    {
        if (ModelState.IsValid)
        {
            var side = model.Side ?? 0;
            model.Height = Math.Sqrt(3) / 2 * side;
            model.Area = side * model.Height / 2;
            model.Circumference = side * 3;
        }

        return View("Triangle", model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}