using Microsoft.AspNetCore.Mvc;
using myblog.Models;
using myblog.Data;
using System.Diagnostics;

namespace myblog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AnaSayfa()
        {
            var me = _context.Me.FirstOrDefault(); // Liste değil, tek kişi
            return View("~/Views/Shared/AdminPages/_AnaSayfa.cshtml", me);
        }

        public IActionResult Hakkımda()
        {
            var education = _context.Education.FirstOrDefault();
            return View("~/Views/Shared/AdminPages/_Hakkımda.cshtml", education);
        }


        public IActionResult Becerilerim()
        {
            var skills = _context.Skills.FirstOrDefault();
            return View("~/Views/Shared/AdminPages/_Becerilerim.cshtml", skills);
        }

        public IActionResult Projelerim()
        {
            var text = _context.Text.FirstOrDefault();
            return View("~/Views/Shared/AdminPages/_Projelerim.cshtml", text);
        }

        public IActionResult İletişim()
        {
            var slang = _context.SLang.FirstOrDefault();
            return View("~/Views/Shared/AdminPages/_İletişim.cshtml", slang);
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
}
