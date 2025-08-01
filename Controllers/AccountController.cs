
using Microsoft.AspNetCore.Mvc;

namespace myblog.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";
            return RedirectToAction("Index", "Login");
        }
    }
}
