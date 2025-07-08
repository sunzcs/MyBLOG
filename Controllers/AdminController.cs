using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myblog.Models;

namespace myblog.Controllers;

public class AdminController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
   
}
