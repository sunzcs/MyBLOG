using Microsoft.AspNetCore.Mvc;
using myblog.Models;
namespace myblog.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";
            return View("~/Views/Admin/Login.cshtml");
        }

        public IActionResult Login(LoginViewModel model)
        {
            if (model.Username == "admin" && model.Password == "admin123")
            {
                HttpContext.Session.SetString("IsLoggedIn", "true");
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.Error = "Kullanıcı adı veya şifre hatalı.";
                return View("~/Views/Admin/Login.cshtml");
            }
        }
    }
}
