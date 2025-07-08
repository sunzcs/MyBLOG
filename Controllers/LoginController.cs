using Microsoft.AspNetCore.Mvc;
using YourProject.Models;

namespace YourProject.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            return View(); // Login sayfası (formun olduğu yer)
        }

        public IActionResult Login(LoginViewModel model)
        {
            // Basit kontrol - normalde veritabanı ile kontrol edilir
            if (model.Username == "admin" && model.Password == "admin123")
            {
                return RedirectToAction("Index", "Admin"); // admin paneline yönlendir
            }
            else if (model.Username == "user" && model.Password == "user123")
            {
                return RedirectToAction("Index", "Home"); // ana sayfaya yönlendir
            }
            else
            {
                ViewBag.Error = "Kullanıcı adı veya şifre hatalı.";
                return View("~/Views/Admin/Login.cshtml"); // tekrar giriş formuna dön
            }
        }
    }
}
