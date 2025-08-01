using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myblog.Models;


namespace myblog.Controllers {
    public class AdminController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {

            var isLoggedIn = HttpContext.Session.GetString("IsLoggedIn");

            if (isLoggedIn == null || isLoggedIn != "true")
            {
                if (HttpContext.Session.GetString("Username") == null)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewBag.Error = "Yetkisiz erişim. Lütfen giriş yapın.";
                    
                }
               
            }

            return View(); // Yetkili kullanıcı admin paneline ulaşır
        }
        public IActionResult AdminIndex()
        {
            return View("~/Views/Admin/Index.cshtml");
        }
        
    }
}

