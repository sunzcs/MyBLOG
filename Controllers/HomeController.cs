using System.Diagnostics;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using myblog.Models;

namespace myblog.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Hakkımda()
    {
     return View("~/Views/Shared/AdminPages/_Hakkımda.cshtml");
    }
    public IActionResult AnaSayfa()
    {
     return View("~/Views/Shared/AdminPages/_AnaSayfa.cshtml");
    }
    public IActionResult Becerilerim()
    {
     return View("~/Views/Shared/AdminPages/_Becerilerim.cshtml");
    }
    public IActionResult Projelerim()
    {
     return View("~/Views/Shared/AdminPages/_Projelerim.cshtml");
    }
    public IActionResult İletişim()
    {
     return View("~/Views/Shared/AdminPages/_İletişim.cshtml");
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
